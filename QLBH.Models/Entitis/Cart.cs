using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Cart : BaseEntity
    {
        public long CartID { get; set; }
        public long Acount_ID { get; set; }
        public Account Acount { get; set; }
        public IEnumerable<Detail_Cart> Detail_Cart { get; set; }
    }
}
