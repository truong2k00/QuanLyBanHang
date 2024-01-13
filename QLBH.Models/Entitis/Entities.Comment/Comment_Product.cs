using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Models.Entitis
{
    public class Comment_Product : DeleteEntity
    {
        public Account Account { get; set; }
        public Product Product { get; set; }
        public string Document {  get; set; }
        public DateTime Datetime_Comment { get; set; }
        public virtual ICollection<Image_Comment> Image_Comment { get; set; }
    }
}
