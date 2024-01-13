using QLBH.Models.DataRequest;
using QLBH.Models.DataResponse;
using QLBH.Models.Entitis;
using QLPT2.Business;
using QLPT2.Commons.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Responsitory.Auth
{
    public interface IAuthServices
    {
        IEnumerable<Account> GetAccounts();
        Task<Tuple<int, string>> Register(Request_Register request_Register);
        Task<ResponcesObject<DataResponseToken>> Login(Request_Login request_Login);
        Task<DataResponseToken> GenenrateRquestToken(Account acount);
        Task<DataResponseToken> RenewToken(string token);
        Task<DataResponCode> ConfirmCode(string UserName, string code);
        Task<DataResponCode> Create_Code(string UserName);
    }
}
