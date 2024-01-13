using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Image_Comment : DeleteEntity
    {
        public string href { get; set; }
        public Comment_Product Comment_Product { get; set; }
    }
}
