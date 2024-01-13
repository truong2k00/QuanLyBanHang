using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.DataRequest
{
    public class Request_Register
    {
        public string Full_Name { get; set; }
        public string User_Name { get; set; }
        public string PassWord { get; set; }
        public string NewPassword { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }
    }
}
