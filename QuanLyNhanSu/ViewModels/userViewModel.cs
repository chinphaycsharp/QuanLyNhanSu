using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.ViewModels
{
    [Serializable]
    public class userViewModel
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public DateTime? loginDate { get; set; }
    }
}
