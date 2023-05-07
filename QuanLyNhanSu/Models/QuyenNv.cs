using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyNhanSu.Models
{
    public partial class QuyenNv
    {
        public string MaQuyen { get; set; }
        public int id { get; set; }
        public int status { get; set; }
        public virtual Quyen MaQuyenNavigation { get; set; }
        public virtual Login idNavigation { get; set; }
    }
}
