using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Bill : DeleteEntity 
    {
        public long Bill_ID { get; set; }
        public DateTime Date_Create { get; set; } = DateTime.Now;
        public long Status_ID { get; set; }
        public Status_Bill Status_Bill { get; set; }
        public long Acount_ID { get; set; }
        public Account Acount { get; set; }
        public long Addess_Receive_ID { get; set; }
        public Addess_Receive Addess_Receive { get; set; }
    }
}
