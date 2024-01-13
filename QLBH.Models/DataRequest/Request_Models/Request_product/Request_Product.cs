using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.DataRequest.Request_Models.Request_product
{
    public class Request_Product
    {
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public long Catogory_ID { get; set; }
        public bool Is_New { get; set; }
        public bool Sale { get; set; }
        public long Quantity { get; set; }
        public long Price { get; set; }
        public long? Price_Sale { get; set; }
    }
}
