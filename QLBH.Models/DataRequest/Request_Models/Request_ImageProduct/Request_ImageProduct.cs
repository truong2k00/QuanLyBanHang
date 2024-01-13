using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.DataRequest.Request_Models.Request_ImageProduct
{
    public class Request_ImageProduct
    {
        public long Product_ID { get; set; }
        public IFormFile file { get;set; }
    }
}
