using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Voucher : DeleteEntity
    {
        public long VoucherId { get; set; }
        public string VoucherName { get; set;}
        public DateTime Release_Date { get; set; }
        public DateTime Expiration_Date { get;set; }
        public long Quantity { get; set; }
        public decimal Reducted_Value { get; set; }
        public long Acount_ID { get; set; }
        public Account Acount { get; set; }
        public bool Work {  get; set; }
    }
}
