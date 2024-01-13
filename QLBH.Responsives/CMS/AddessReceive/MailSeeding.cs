using QLBH.Commons;
using QLBH.Models.Entitis;
using QLBH.Responsitory.Auth;
using QLBH.Responsives.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Responsitory.CMS.AddessReceive
{
    public class MailSeeding
    {
        public static async Task<List<ConfirmEmail>> NewConfirmEmail(IBaseReponsitory<MailSetting> baseReponsitory, EmailCode code)
        {
            return new List<ConfirmEmail>
            {
                new ConfirmEmail
                {
                    CodeiVerification = AuthServices.GenerateCode().ToString(),
                        Expired = DateTime.Now.AddMinutes(10),
                        IsConfirmed = false,
                        MailSetting = await baseReponsitory.GetAsync(record => record.Code == code)
                }
            };
        }
    }
}
