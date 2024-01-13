using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPT2.Commons.Handle
{
    public class EmailValidate
    {
        public static bool IsValidateEmail(string Email)
        {
            var checkEmail = new EmailAddressAttribute();
            return checkEmail.IsValid(Email);
        }
    }
}
