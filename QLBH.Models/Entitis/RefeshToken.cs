using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class RefeshToken : DeleteEntity
    {
        public long RefeshToken_ID { get; set; }
        public string Token { get; set; }
        public DateTime Date_Expired { get; set; }
        public long Acount_ID { get; set; }
        public Account Acount { get; set; }
    }
}
