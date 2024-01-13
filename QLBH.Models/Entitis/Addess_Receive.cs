using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Addess_Receive : DeleteEntity
    {
        public long Addess_Receive_ID { get; set; }
        public string Addess { get; set; }
        public string Phone { get; set; }
        public string Full_Name { get; set; }
        public string Describe { get; set; }
        public string Email { get; set; }
        public bool Confirm { get; set; }
        public long Acount_ID { get; set; }
        public Account Acount { get; set; }
        public IEnumerable<Bill> Bill { get; set; }
        public virtual ICollection<ConfirmEmail> ConfirmEmail { get; set; }
    }
}
