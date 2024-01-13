using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using MimeKit;

namespace QLPT2.Commons.Handle
{
    public class EmailSender
    {
        public static Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "tbxuan611@gmail.com";
            var pas = "rkuaiiybxkkaojwr";

            var client = new SmtpClient("Smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pas)
            };
            var mailseeding = new MailMessage(from: mail,
                                                        to: email,
                                                        subject,
                                                        body: message)
            {
                IsBodyHtml = true
            };
            return client.SendMailAsync(mailseeding);
        }
    }
}
