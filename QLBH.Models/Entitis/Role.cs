using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Role : BaseEntity
    {
        public long Role_ID { get; set; }
        public string Role_Name { get; set;}
        public ICollection<Decentralization> Decentralization { get; set; }
    }
}
