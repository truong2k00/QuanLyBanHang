using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Detail_Cart : BaseEntity
    {
        public long Detail_Cart_ID { get; set; }
        public long Cart_ID { get; set; }
        public Cart Cart { get; set; }
        public long Product_ID { get; set; }
        public Product Product { get; set; }
        public long Quantity { get; set; }
        public long Price { get; set; }
        public decimal Cash {  get; set; }
    }
}
