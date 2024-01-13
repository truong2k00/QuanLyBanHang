using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.DataRequest
{
    public class RequestFiles
    {
        public List<IFormFile> Files { get; set; }
    }
}
