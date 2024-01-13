using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Models.Entitis
{
    public class FeedBack : BaseEntity
    {
        public string FeedBack_Quality { get; set; }
        public string Opinion { get; set; }
        public Star star { get; set; }
        public Account Acount { get; set; }
        public Product Product { get; set; }
    }
}
