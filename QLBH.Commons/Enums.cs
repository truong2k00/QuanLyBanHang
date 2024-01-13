using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.Commons
{
    public class Enums
    {
        public enum UserType
        {
            External,
            Internal
        }
        public enum RoleType
        {
            Admin = 100,
            User = 200,
            Guest = 201,
            Moderator = 301,
            Editor = 302,
            Manager = 303,
            Superuser = 400
        }
        public enum EmailCode
        {
            XacThucDangKy = 100,
            XacThucEmail = 101,
            XacThucQuyenMatKhau = 200,
            DatHangThanhCong = 300,
            GiaoHangThanhCong = 302
        }
        public enum Star
        {
            one = 1,
            two = 2,
            three = 3,
            four = 4,
            five = 5
        }
    }
}
