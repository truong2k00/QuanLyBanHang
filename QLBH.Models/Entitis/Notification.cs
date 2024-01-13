using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Notification : BaseEntity
    {
        public long Notification_ID { get; set; }
        public string Notification_Title { get; set; }
        public string Notification_Description { get; set; }
        public long Acount_ID { get; set; }
        public Account Acount { get; set; }
    }
}
