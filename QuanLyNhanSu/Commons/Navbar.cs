using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Commons
{
    public class Navbar
    {
        public string name { get; set; }
        public string role { get; set; }
        public string url { get; set; }
        public string action { get; set; }
        public string param { get; set; }

        public static List<Navbar> navbars = new List<Navbar>()
        {
            new Navbar()
            {
                name = "Hệ thống",
                role = "ViewRole",
                url = "Role",
                action ="Index",

            },
             new Navbar()
            {
                name = "Tài khoản",
                role = "ViewAccount",
                 url = "Account",
                 action ="Index"
            },
              new Navbar()
            {
                name = "Nhân viên",
                role = "ViewStaff",
                 url = "Employee",
                 action ="Index"
            },
               new Navbar()
            {
                name = "Hợp đồng",
                role = "ViewContract",
                 url = "Contract",
                 action ="Index"
            },
               new Navbar()
            {
                name = "Chức vụ",
                role = "ViewPosition",
                 url = "Position",
                 action ="Index"
            },
                  new Navbar()
            {
                name = "Doanh thu",
                role = "ViewRevenue",
                 url = "RevenueEmployee",
                 action ="Index"
            },
                  new Navbar()
            {
                name = "Hồ sơ cá nhân",
                role = "DetailStaff",
                 url = "Employee",
                 action ="Detail"
            },
                  new Navbar()
            {
                name = "Hợp đồng cá nhân",
                role = "DetailContract",
                 url = "Contract",
                 action ="Detail"
                  },
                  new Navbar()
            {
                name = "Tài khoản cá nhân",
                role = "DetailAccount",
                 url = "Account",
                 action ="Detail"
            }
        };
    }
}
