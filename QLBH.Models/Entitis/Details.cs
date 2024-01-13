using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Details : BaseEntity
    {
        public long Detail_ID { get; set; }
        public string Introduce { get; set; }
        public string Detail_Introduce { get; set; }
        public long Product_ID { get; set; }
        public Product Product { get; set; }
    }
}
