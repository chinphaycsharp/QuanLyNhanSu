using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyNhanSu.Models
{
    public partial class DoanhthuNv
    {
        public int Ma { get; set; }
        public string Msnv { get; set; }
        public decimal DoanhThu { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Status { get; set; }

        public virtual HosoNv MsnvNavigation { get; set; }
    }
}
