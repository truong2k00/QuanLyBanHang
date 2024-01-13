using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.DataResponse.Response_Models
{
    public class DataRespon_CommentProduct
    {
        public string User {  get; set; }
        public string Comment { get; set; }
        public DateTime Date_create { get; set; }
    }
}
