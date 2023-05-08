using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyNhanSu.Models
{
    public partial class ViewDoanhthuNv
    {
        public int Ma { get; set; }
        public decimal DoanhThu { get; set; }
        public string Msnv { get; set; }
        public string HotenNv { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? Status { get; set; }
    }
}
