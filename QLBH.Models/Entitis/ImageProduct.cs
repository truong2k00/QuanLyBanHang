using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class ImageProduct : BaseEntity
    {
        public long Image_ID { get; set; }
        public string Image_Url { get; set; }
        public long Product_ID { get; set;}
        public Product Product { get; set;}
    }
}
