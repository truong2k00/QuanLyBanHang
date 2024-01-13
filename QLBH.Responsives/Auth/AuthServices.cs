using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QLBH.Commons;
using QLBH.Commons.Handle;
using QLBH.Models;
using QLBH.Models.DataRequest;
using QLBH.Models.DataResponse;
using QLBH.Models.Entitis;
using QLBH.Responsives.Base;
using QLPT2.Business;
using QLPT2.Commons.Handle;
using QLPT2.Commons.Responces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static QLBH.Commons.Common_Constants;
using static QLBH.Commons.Enums;
using BCryptNet = BCrypt.Net.BCrypt;
using ErrorLogin = QLBH.Commons.Common_Constants.Login;
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
using clames = QLBH.Commons.Common_Constants.Clames;
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
using ErrorRegister = QLBH.Commons.Common_Constants.Register_Create;
using QLBH.Responsitory.CMS.AddessReceive;

namespace QLBH.Responsitory.Auth
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _appDbContext;
        private readonly IBaseReponsitory<Account> _baseReponsitory;
        private readonly IBaseReponsitory<RefeshToken> _baseRefReponsitory;
        private readonly IBaseReponsitory<Decentralization> _baseDeReponsitory;
        private readonly IBaseReponsitory<MailSetting> _baseMailsettingReponsitory;
        private readonly IBaseReponsitory<ConfirmEmail> _baseConfReponsitory;
        private readonly ResponcesObject<DataResponseToken> _responcesObject;

        public AuthServices(IHttpContextAccessor contextAccessor
            , IBaseReponsitory<Account> baseReponsitory
            , AppDbContext appDbContext, IConfiguration configuration
            , ResponcesObject<DataResponseToken> responcesObject
            , IBaseReponsitory<MailSetting> baseMailsettingReponsitory
            , IBaseReponsitory<Decentralization> baseDeReponsitory
            , IBaseReponsitory<ConfirmEmail> baseConfDeReponsitory)
        {
            _baseConfReponsitory = baseConfDeReponsitory;
            _baseDeReponsitory = baseDeReponsitory;
            _contextAccessor = contextAccessor;
            _baseReponsitory = baseReponsitory;
            _responcesObject = responcesObject;
            _appDbContext = appDbContext;
            _configuration = configuration;
            _baseMailsettingReponsitory = baseMailsettingReponsitory;
            _baseDeReponsitory = baseDeReponsitory;
        }

        public async Task<DataResponseToken> GenenrateRquestToken(Account Account)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_configuration.GetSection(AppSettingKeys.AUTH_SECRET).Value);

            var RoleID = (await _baseDeReponsitory.GetAllAsync(record => record.Account.ID == Account.ID && record.Deleted == false))
                .Select(x => (int)x.role).Min();

            var roleName = string.Join(";", _appDbContext.Role.Where(record => record.Role_ID == RoleID).Select(x => x.Role_Name));

            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(clames.ID, Account.ID.ToString()),
                    new Claim(ClaimTypes.Email, Account.Email),
                    new Claim(clames.USER, Account.User_Name),
                    new Claim(ClaimTypes.Role, roleName)
                }),
                Expires = DateTime.Now.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDes);
            var accesstoken = jwtTokenHandler.WriteToken(token);
            //generate Refesh Token
            var refreshToken = GenerateRefreshToken();
            //Add refesh Token
            AddRefeshToken(Account, refreshToken);

            return new DataResponseToken
            {
                AccessToken = accesstoken,
                RefreshToken = refreshToken
            };
        }
        public async void AddRefeshToken(Account account, string refeshToken)
        {
            var refeshTokens = new List<RefeshToken>
            {
                new RefeshToken
                {
                    Token = refeshToken,
                        Date_Expired = DateTime.Now.AddDays(1),
                        Acount_ID = account.ID
                }
            };
            account.RefeshToken = refeshTokens;
            await _baseReponsitory.UpdateAsync(account);
        }
        public string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var item = RandomNumberGenerator.Create())
            {
                item.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _appDbContext.Account.AsQueryable();
        }

        public async Task<ResponcesObject<DataResponseToken>> Login(Request_Login request_Login)
        {
            if (request_Login.UserName.IsNullOrEmpty() || request_Login.Password.IsNullOrEmpty())
                return _responcesObject.ResponcesError(StatusCodes.Status400BadRequest, ErrorLogin.Request_NULL, null);

            if (_appDbContext.Account.Any(x => x.User_Name == request_Login.UserName || x.Email == request_Login.UserName && x.Deleted == false))
            {
                var account = await _baseReponsitory.GetAsync(x => x.User_Name == request_Login.UserName || x.Email == request_Login.UserName && x.Deleted == false);
                bool CheckPass = BCryptNet.Verify(request_Login.Password, account.PassWord);
                if (!CheckPass)
                    return _responcesObject.ResponcesError(StatusCodes.Status400BadRequest, ErrorLogin.Error_Pass, null);

                return _responcesObject.ResponcesSuccess(SUCCESS, await GenenrateRquestToken(account));
            }
            return _responcesObject.ResponcesError(StatusCodes.Status400BadRequest, ErrorLogin.Error_USER_NAME, null);
        }
        public List<Cart> GenerateCart()
        {
            return new List<Cart>
            {
                new Cart {}
            };
        }
        public async Task<Tuple<int, string>> Register(Request_Register request_Register)
        {
            var accounts = await _baseReponsitory.GetAllAsync(record => record.IsConfirm < DateTime.Now && record.Deleted == false && record.Work == false);

            if (accounts != null)
            {
                foreach (var item in accounts)
                {
                    item.Deleted = true;
                }
                await _baseReponsitory.UpdateAsync(accounts);
            }

            if (request_Register.PassWord != request_Register.NewPassword)
                return Tuple.Create(StatusCodes.Status402PaymentRequired, ErrorRegister.PASSWORD_ERROR);
            //check Password
            var checkpass = PasswordValidate.CheckPass(request_Register.NewPassword);
            if (checkpass != Hepper.Success)
                return Tuple.Create(StatusCodes.Status402PaymentRequired, Handle.ConLog(checkpass));
            //check phone_number
            if (!PasswordValidate.Number(request_Register.Phone_Number) || request_Register.Phone_Number.Length != 10)
                return Tuple.Create(StatusCodes.Status402PaymentRequired, ErrorRegister.Phone_ERROR_TYPE);
            //check is validate Email
            if (!EmailValidate.IsValidateEmail(request_Register.Email))
                return Tuple.Create(StatusCodes.Status402PaymentRequired, ErrorRegister.Error_Email_TYPE);
            //Phone account Checked
            if (_appDbContext.Account.Any(x => x.Phone_Number == request_Register.Phone_Number && x.Deleted == false))
                return Tuple.Create(StatusCodes.Status402PaymentRequired, ErrorRegister.Phone_ERROR);
            //Email account Checked
            if (_appDbContext.Account.Any(x => x.Email == request_Register.Email && x.Deleted == false))
                return Tuple.Create(StatusCodes.Status402PaymentRequired, ErrorRegister.Error_Email);

            if (_appDbContext.Account.Any(x => x.User_Name == request_Register.User_Name && x.Deleted == false))
                return Tuple.Create(StatusCodes.Status402PaymentRequired, ErrorRegister.Error_USER);

            else
            {
                var account = await GenerateAccount(request_Register);
                await _baseReponsitory.CreateAsync(account);

                SenderEmail(account);

                return Tuple.Create(StatusCodes.Status200OK, SUCCESS);
            }
        }
        public async void SenderEmail(Account account)
        {
            var confirm = await _baseConfReponsitory.GetAsync(record => record.Account.ID == account.ID && record.IsConfirmed == false);
            var mailsetting = await _baseMailsettingReponsitory.GetAsync(record => record.ID == confirm.MailSetting.ID);

            await EmailSender.SendEmailAsync(account.Email, mailsetting.TieuDe + "(" + mailsetting.Title + ")", string.Format(mailsetting.NoiDung, confirm.CodeiVerification) + string.Format(mailsetting.Description, confirm.CodeiVerification));
        }
        public async Task<Account> GenerateAccount(Request_Register request_Register)
        {
            return new Account
            {
                Account_ID = 0,
                Image_url = "./",
                Date_Create = DateTime.Now,
                Full_Name = FirstUpper.ToFirstUpper(request_Register.Full_Name),
                User_Name = request_Register.User_Name,
                PassWord = BCryptNet.HashPassword(request_Register.NewPassword),
                Phone_Number = request_Register.Phone_Number,
                Email = request_Register.Email,
                Address = "",
                Number_CCCD = "",
                IsConfirm = DateTime.Now.AddDays(1),
                Decentralizations = new List<Decentralization>
                {
                    new Decentralization
                    {
                        role = RoleType.Guest
                    }
                },
                Cart = GenerateCart(),
                ConfirmEmail = await MailSeeding.NewConfirmEmail(_baseMailsettingReponsitory, Enums.EmailCode.XacThucDangKy),
                Work = false
            };
        }
        public static int GenerateCode()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999);
        }
        public async Task<DataResponseToken> RenewToken(string token)
        {
            var refeshtoken = await _baseRefReponsitory.GetAsync(x => x.Token == token && x.Date_Expired >= DateTime.Now);
            if (refeshtoken == null)
                return new DataResponseToken()
                {
                    AccessToken = "",
                    RefreshToken = ""
                };
            else
            {
                var Account = await _baseReponsitory.GetAsync(x => x.ID == refeshtoken.Acount_ID);
                return await GenenrateRquestToken(Account);
            }
        }

        public async Task<DataResponCode> ConfirmCode(string UserName, string code)
        {
            var account = await _baseReponsitory.GetAsync(record => record.User_Name == UserName && record.Deleted == false);
            var Confirm = await _baseConfReponsitory.GetAsync(record => record.Account.ID == account.ID && record.IsConfirmed == false && record.Expired >= DateTime.Now && record.Deleted == false);
            if (Confirm == null) return new DataResponCode { Status = StatusCodes.Status404NotFound, Message = CodeVerification.Message_404_code };
            else
            {
                if (Confirm.CodeiVerification == code)
                {
                    account.Work = true;
                    Confirm.IsConfirmed = true;
                    await _baseReponsitory.UpdateAsync(account);
                    await _baseConfReponsitory.UpdateAsync(Confirm);
                    return new DataResponCode
                    {
                        Status = StatusCodes.Status200OK,
                        Message = SUCCESS
                    };
                }
                else
                {
                    return new DataResponCode
                    {
                        Status = StatusCodes.Status408RequestTimeout,
                        Message = CodeVerification.Message_408_code
                    };
                }
            }
        }
        public async Task<DataResponCode> Create_Code(string UserName)
        {
            var account = await _baseReponsitory.GetAsync(record => record.User_Name == UserName && record.Deleted == false);
            var confirm = _appDbContext.ConfirmEmail.Where(record => record.Account.ID == account.ID);
            if (confirm != null)
            {
                foreach (var item in confirm)
                {
                    item.Deleted = true;
                }
                await _baseConfReponsitory.UpdateAsync(confirm);
            }
            account.ConfirmEmail = await MailSeeding.NewConfirmEmail(_baseMailsettingReponsitory, Enums.EmailCode.XacThucDangKy);
            _appDbContext.SaveChanges();
            if (account == null) return new DataResponCode
            {
                Status = StatusCodes.Status404NotFound,
                Message = CodeVerification.Message_404_Account
            };
            else SenderEmail(account);
            return new DataResponCode
            {
                Status = StatusCodes.Status200OK,
                Message = SUCCESS
            };
        }
    }
}
