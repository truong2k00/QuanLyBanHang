using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Models.Entitis
{
    public class Account : DeleteEntity
    {
        public long Account_ID { get; set; }
        public string Image_url { get; set; }
        public DateTime Date_Create { get; set; }
        public DateTime? Date_Update { get; set; }
        public string Full_Name { get; set; }
        public string User_Name { get; set; }
        public string PassWord { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }
        public DateTime IsConfirm { get; set; }
        public string Address { get; set; }
        public string Number_CCCD { get; set; }
        public bool Work { get; set; }
        public virtual ICollection<Decentralization> Decentralizations { get; set; }
        public virtual ICollection<Addess_Receive> Addess_Receive { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<FeedBack> FeedBack { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Voucher> Voucher { get; set; }
        public virtual ICollection<RefeshToken> RefeshToken { get; set; }
        public virtual ICollection<ConfirmEmail> ConfirmEmail { get; set; }
    }
}
