using QuanLyNhanSu.ViewModels.RoleEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.ViewModels.Login
{
    [Serializable]
    public class userViewModel
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public List<RoleEmployeeViewModel> roles { get; set; }
    }
}
