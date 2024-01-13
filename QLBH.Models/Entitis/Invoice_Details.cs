using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Invoice_Details : BaseEntity
    {
        public long Invoice_Id { get; set; }
        public long Product_ID { get; set; }
        public Product Product { get; set; }
        public long Quantity { get; set; }
        public decimal Cash { get; set; }
        public long Bill_ID {  get; set; }
        public Bill Bill {  get; set; }
    }
}
