using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyNhanSu.Models
{
    public partial class QuyenNv
    {
        public string MaQuyen { get; set; }
        public string Msnv { get; set; }

        public virtual Quyen MaQuyenNavigation { get; set; }
        public virtual HosoNv MsnvNavigation { get; set; }
    }
}
