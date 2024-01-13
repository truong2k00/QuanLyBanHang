using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Status_Bill : DeleteEntity
    {
        public long Status_ID { get; set; }
        public string Status_Name { get; set; }
        public IEnumerable<Bill> Bill { get; set; }
    }
}
