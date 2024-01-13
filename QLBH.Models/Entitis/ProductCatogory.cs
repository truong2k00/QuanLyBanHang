using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class ProductCatogory : DeleteEntity
    {
        public long Catogory_ID { get; set; }
        public string CatogoryName { get; set;}
        public virtual ICollection<Product> Product {  get; set; }
    }
}
