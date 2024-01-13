using Microsoft.AspNetCore.Http;
using QLBH.Commons.Handle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPT2.Commons.Handle
{
    public class PasswordValidate
    {
        public static bool length(string password)
        {
            if (password.Length < 8 || password.Length > 14)
                return false;
            return true;
        }
        public static bool IsUpper(string password)
        {
            if (!password.Any(char.IsUpper))
                return false;
            else return true;
        }
        public static bool Islower(string password)
        {
            if (!password.Any(char.IsUpper))
                return false;
            else return true;
        }
        public static bool space(string password)
        {
            if (password.Contains(" "))
                return false;
            else return true;
        }
        public static bool Number(string password)
        {
            if (!password.Any(char.IsDigit))
                return false;
            else return true;
        }
        public static bool special_character(string password)
        {
            string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialChArray = specialCh.ToCharArray();
            foreach (char ch in specialChArray)
            {
                if (password.Contains(ch))
                    return true;
            }
            return false;
        }
        public static Hepper CheckPass(string password)
        {
            if (!length(password))
                return Hepper.length;
            if (!IsUpper(password))
                return Hepper.IsUpper;
            if (!Islower(password))
                return Hepper.Islower;
            if (!space(password))
                return Hepper.space;
            if (!special_character(password))
                return Hepper.special_character;
            else return Hepper.Success;
        }
    }
}
