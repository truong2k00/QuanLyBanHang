using Microsoft.AspNetCore.Http;
using QLBH.Models.DataRequest.Request_Models.Request_AddessReceive;
using QLBH.Models.DataResponse.Response_Models.DataRespon_AddessReceive;
using QLBH.Models.Entitis;
using QLBH.Responsives.Base;
using QLPT2.Commons.Handle;
using static QLBH.Commons.Enums;
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
using clames = QLBH.Commons.Common_Constants.Clames;
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

namespace QLBH.Responsitory.CMS.AddessReceive
{
    public class AddessReceiveServices : IAddessReceive<Respon_AddessReceive, long>
    {
        private readonly IBaseReponsitory<Addess_Receive> _baseReponsitory;
        private readonly IBaseReponsitory<Account> _baseAccountReponsitory;
        private readonly IBaseReponsitory<ConfirmEmail> _baseConfirmReponsitory;
        private readonly IBaseReponsitory<MailSetting> _baseMailSettingReponsitory;
        private readonly IHttpContextAccessor _context;

        public AddessReceiveServices(IBaseReponsitory<Addess_Receive> baseReponsitory
            , IBaseReponsitory<MailSetting> baseMailSettingReponsitory
            , IBaseReponsitory<Account> baseAccountReponsitory
            , IBaseReponsitory<ConfirmEmail> baseConfirmReponsitory
            , IHttpContextAccessor context)
        {
            _baseAccountReponsitory = baseAccountReponsitory;
            _baseConfirmReponsitory = baseConfirmReponsitory;
            _baseMailSettingReponsitory = baseMailSettingReponsitory;
            _baseReponsitory = baseReponsitory;
            _context = context;
        }

        public async Task<Respon_AddessReceive> Create(long AccountID,Request_AddessReceive item)
        {
            Addess_Receive addess = new Addess_Receive
            {
                Acount = await _baseAccountReponsitory.GetByIDAsync(long.Parse(_context.HttpContext.User.FindFirst(clames.ID).Value)),
                Addess = item.Addess,
                Phone = item.Phone,
                Full_Name = item.Full_Name,
                Describe = item.Describe,
                Email = item.Email,
                Confirm = false,
                ConfirmEmail = await MailSeeding.NewConfirmEmail(_baseMailSettingReponsitory, EmailCode.XacThucEmail)
            };
            await _baseReponsitory.CreateAsync(addess);
            SenderEmail(addess);
            return new Respon_AddessReceive
            {
                Addess = item.Addess,
                Phone = item.Phone,
                Full_Name = item.Full_Name,
                Describe = item.Describe,
                Email = item.Email
            };
        }

        public async void SenderEmail(Addess_Receive addess_Receive)
        {
            var confirm = await _baseConfirmReponsitory.GetAsync(record => record.Addess_Receive.ID == addess_Receive.ID && record.IsConfirmed == false);
            var mailsetting = await _baseMailSettingReponsitory.GetAsync(record => record.ID == confirm.MailSetting.ID);

            await EmailSender.SendEmailAsync(confirm.Account.Email, mailsetting.TieuDe + "(" + mailsetting.Title + ")", string.Format(mailsetting.NoiDung, confirm.CodeiVerification) + string.Format(mailsetting.Description, confirm.CodeiVerification));

        }
        public Task<bool> Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public Task<Respon_AddessReceive> Update(long ID, Request_AddessReceive item)
        {
            throw new NotImplementedException();
        }
    }
}
