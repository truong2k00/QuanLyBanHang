using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QLBH.Commons.Enums;

namespace QLBH.Models.Entitis
{
    public class Decentralization : DeleteEntity
    {
        public long Account_ID { get; set; }
        public virtual Account Account { get; set; }
        public RoleType role { get; set; }
        public Role Role { get; set; }
    }
}
