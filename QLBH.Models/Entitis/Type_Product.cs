using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Type_Product : BaseEntity
    {
        public long Type_ID { get; set; }
        public string Type_Name { get; set; }
        public string Image {  get; set; }
        public long Product_ID { get; set; }
        public Product Product { get; set; }
    }
}
