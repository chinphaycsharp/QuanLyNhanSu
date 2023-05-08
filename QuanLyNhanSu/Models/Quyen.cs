using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyNhanSu.Models
{
    public partial class Quyen
    {
        public Quyen()
        {
            QuyenNvs = new HashSet<QuyenNv>();
        }

        public string MaQuyen { get; set; }
        public string MoTa { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<QuyenNv> QuyenNvs { get; set; }
    }
}
