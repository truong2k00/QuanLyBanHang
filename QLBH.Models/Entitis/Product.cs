using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Product : DeleteEntity
    {
        public long Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public string Meta_Product { get; set; }
        public long Catogory_ID { get; set; }
        public ProductCatogory ProductCatogory { get; set; }
        public bool Is_New { get; set; }
        public bool Sale { get; set; }
        public DateTime? Date_Delete { get; set; }
        public bool Is_Deleted { get; set; }
        public long Quantity { get; set; }
        public long Price { get; set; }
        public long? Price_Sale { get; set; }
        public long Acount_ID { get; set; }
        public Account Acount { get; set; }
        public long Evaluate { get; set; }
        public IEnumerable<Detail_Cart> Detail_Cart { get; set; }
        public IEnumerable<Details> Details { get; set; }
        public virtual ICollection<ImageProduct> ImageProduct { get; set; }
        public virtual ICollection<Comment_Product> Comment_Product { get; set; }
    }
}
