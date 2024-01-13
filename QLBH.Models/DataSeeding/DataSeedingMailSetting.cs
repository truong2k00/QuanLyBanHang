using Microsoft.EntityFrameworkCore;
using QLBH.Commons;
using QLBH.Models.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QLBH.Models.Seeding
{
    public partial class DataSeeding
    {
        public static void DataSeedingEmail(AppDbContext appDbContext)
        {
            if (!appDbContext.MailSetting.Any())
            {
                appDbContext.MailSetting.AddRange(GenerateMailSetting());
                appDbContext.SaveChanges();
            }
        }
        public static List<MailSetting> GenerateMailSetting()
        {
            return new List<MailSetting>
            {
                new MailSetting
                {
                    Code = Enums.EmailCode.XacThucDangKy,
                    TieuDe = "Xác Thực Đăng Ký",
                    Title = "Verify Registration",
                    NoiDung ="<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#000000\">Kính Gửi Ông/Bà:</span></span></span></span></span></span></p>\r\n\r\n<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#000000\">Để hoàn tất đăng ký hồ sơ, vui lòng nhập mã xác thực tài khoản:</span></span></span></span></span></span></p>\r\n\r\n<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#000000\">{0}</span></span></span></span></span></span></p>\r\n\r\n<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><b><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#ff0000\"><span style=\"font-weight:bold\">Mã xác thực {0} có thời hạn 10 phút nếu quá thời gian vui lòng yêu cầu gửi lại mã xác nhận.</span></span></span></span></b></span></span></span></p>\r\n\r\n<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#000000\">(Lưu Ý: Vui lòng không hồi đáp reply lại thư này.)</span></span></span></span></span></span></p>\r\n\r\n<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><b><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#000000\"><span style=\"font-weight:bold\">Xin trân trọng cảm ơn!</span></span></span></span></b></span></span></span></p>\r\n\r\n<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><b><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#000000\"><span style=\"font-weight:bold\">"+Common_Constants.NameSystem+"</span></span></span></span></b></span></span></span></p>",
                    Description ="<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#000000\">Dear mr and mrs:</span></span></span></span></span></span></p>\r\n\r\n<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#000000\">To complete profile registration, please enter the account verification code:</span></span></span></span></span></span></p>\r\n\r\n<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#000000\">{0}</span></span></span></span></span></span></p>\r\n\r\n<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><b><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#ff0000\"><span style=\"font-weight:bold\">The verification code {0} is valid for 10 minutes. If the time has passed, please request to resend the verification code.</span></span></span></span></b></span></span></span></p>\r\n\r\n<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#000000\">\r\n(Note: Please do not reply to this message.)</span></span></span></span></span></span></p>\r\n\r\n<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><b><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#000000\"><span style=\"font-weight:bold\">Thank you very much!</span></span></span></span></b></span></span></span></p>\r\n\r\n<p style=\"margin-bottom:10px\"><span style=\"font-size:11pt\"><span style=\"line-height:107%\"><span style=\"font-family:Calibri\"><b><span style=\"font-size:10.5000pt\"><span style=\"font-family:'Source Sans Pro'\"><span style=\"color:#000000\"><span style=\"font-weight:bold\">"+Common_Constants.NameSystem+"</span></span></span></span></b></span></span></span></p>"
                },
                new MailSetting
                {
                    Code = Enums.EmailCode.XacThucQuyenMatKhau,
                    TieuDe ="Xác thực quyên mật khẩu",
                    Title = "Authenticate password",
                    NoiDung = "<h1>Mã xác nhận lấy lại mật khẩu tài khoản:\r\n</h1>\r\n\r\n<p>\r\n\t{0}\r\n</p>\r\n\r\n<p>\r\n\t&nbsp;\r\n</p>\r\n",
                    Description = "<h1>Confirmation code to retrieve account password:\r\n</h1>\r\n\r\n<p>\r\n\t{0}\r\n</p>\r\n\r\n<p>\r\n\t&nbsp;\r\n</p>\r\n"
                },
                new MailSetting
                {
                    Code = Enums.EmailCode.DatHangThanhCong,
                    TieuDe = "Xác nhận gửi hàng",
                    Title = "Delivery confirmation",
                    NoiDung = "\"<figure class=\\\"image\\\"><img src=\\\"https://res.cloudinary.com/dnitjp0ng/image/upload/v1705076672/samples/QLBH/lngsogzujuhvbc1k0w8x.jpg\\\"></figure><p style=\\\"text-align:center;\\\"><span style=\\\"color:#000000;font-size:14.0000pt;\\\"><strong>THÔNG BÁO CỦA "+Common_Constants.NameSystem+"</strong></span></p><p><span style=\\\"color:#000000;font-size:14.0000pt;\\\"><strong>Kính gửi Ông/Bà: Kiện hàng đã được giao cho đơn vị vận chuyển.</strong></span></p><p><span style=\\\"color:#000000;font-size:14.0000pt;\\\">"+Common_Constants.NameSystem+" thông báo cho ông/bà được biết và theo dõi kiện hàng:</span></p><p><span style=\\\"color:#000000;font-size:14.0000pt;\\\">Đơn hàng sẽ được giao trong thời gian tới quý khách vui lòng để ý điện thoại.</span></p><p>&nbsp;</p><p><span style=\\\"color:#000000;font-size:14.0000pt;\\\">Quá trình sẽ giao hàng được cập nhật trên website.</span></p><p>&nbsp;</p><p><span style=\\\"color:#000000;font-size:14.0000pt;\\\">Nếu có vấn đề vui lòng liên hệ qua địa chỉ email:"+Common_Constants.Email+" hoặc Hotline:"+Common_Constants.Hotline+".</span></p><p>&nbsp;</p><p><span style=\\\"color:#000000;font-size:14.0000pt;\\\"><strong>Trân trọng.</strong></span><br><span style=\\\"color:#000000;font-size:14.0000pt;\\\"><strong>"+Common_Constants.NameSystem+"</strong></span></p><figure class=\\\"image\\\"><img src=\\\"https://res.cloudinary.com/dnitjp0ng/image/upload/v1705077442/samples/QLBH/yhgi4qnrqxlqecdpysw2.png\\\"></figure>\""
                },
                new MailSetting
                {
                    Code = Enums.EmailCode.XacThucEmail,
                    TieuDe ="Xác thực địa chỉ",
                    Title = "Verify address",
                    NoiDung = "<h1>Bạn có 10 phút để nhập mã xác nhận, mã xác nhận của bạn là:\r\n</h1>\r\n\r\n<p>\r\n\t{0}\r\n</p>\r\n\r\n<p>\r\n\t&nbsp;\r\n</p>\r\n",
                    Description = "<h1>You have 10 minutes to enter the confirmation code, your confirmation code is:\r\n</h1>\r\n\r\n<p>\r\n\t{0}\r\n</p>\r\n\r\n<p>\r\n\t&nbsp;\r\n</p>\r\n"
                }
            };
        }
    }
}
