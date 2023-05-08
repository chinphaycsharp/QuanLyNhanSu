using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyNhanSu.Models
{
    public partial class QuyenNv
    {
        public string MaQuyen { get; set; }
        public int IdLogin { get; set; }
        public int? Status { get; set; }

        public virtual Login IdLoginNavigation { get; set; }
        public virtual Quyen MaQuyenNavigation { get; set; }
    }
}
