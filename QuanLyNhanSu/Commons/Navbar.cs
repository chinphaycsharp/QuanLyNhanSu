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

        public static List<Navbar> navbars = new List<Navbar>()
        {
            new Navbar()
            {
                name = "Hệ thống",
                role = "ViewRole",
                url = "Role"
            },
             new Navbar()
            {
                name = "Tài khoản",
                role = "ViewAccount",
                 url = "Account"
            },
              new Navbar()
            {
                name = "Nhân viên",
                role = "ViewEmployee",
                 url = "Employee"
            },
               new Navbar()
            {
                name = "Hợp đồng",
                role = "ViewContract",
                 url = "Contract"
            },
               new Navbar()
            {
                name = "Chức vụ",
                role = "ViewPosition",
                 url = "Position"
            }
        };
    }
}
