using Microsoft.Identity.Client;
using QLBH.Models.DataRequest.Request_Models.Request_product;
using QLBH.Models.Entitis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.DataResponse.Response_Models.DataResponse_product
{
    public class DataResponse_Product : Request_Product
    {
        public long Product_ID { get; set; }
        public long Account_ID { get; set; }
        public string Meta_Product { get; set; }
        public long Evaluate { get; set; }
        public virtual ICollection<ImageProduct> ImageProduct { get; set; }
    }
}
