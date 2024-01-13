using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class ConfirmEmail : DeleteEntity
    {
        public long ConfirmEmail_ID { get; set; }
        public string CodeiVerification { get; set; }
        public DateTime Expired { get; set; }
        public bool IsConfirmed { get; set; }
        public long Account_ID { get; set; }
        public Account Account { get; set; }
        public long Addess_Receive_ID { get; set; }
        public Addess_Receive Addess_Receive { get; set; }
        public long MailSettingID {  get; set; }
        public MailSetting MailSetting { get; set; }
    }
}
