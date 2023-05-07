using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyNhanSu.Models
{
    public partial class HosoNv
    {
        public HosoNv()
        {
            Hopdonglds = new HashSet<Hopdongld>();
        }

        public string Msnv { get; set; }
        public int? Idlogin { get; set; }
        public string HotenNv { get; set; }
        public string Gioitinh { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string QueQuan { get; set; }
        public string Sđt { get; set; }
        public string SoCmtnd { get; set; }
        public DateTime? Ngaycap { get; set; }
        public string Noicap { get; set; }
        public string Điachithuongtru { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int status { get; set; }
        public virtual Login IdloginNavigation { get; set; }
        public virtual ICollection<Hopdongld> Hopdonglds { get; set; }
    }
}
