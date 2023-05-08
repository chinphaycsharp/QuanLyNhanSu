using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyNhanSu.Models
{
    public partial class Hopdongld
    {
        public string SoHd { get; set; }
        public string Mscv { get; set; }
        public string Msnv { get; set; }
        public string LoaiHd { get; set; }
        public DateTime? Tgianbatdau { get; set; }
        public DateTime? Tgianketthuc { get; set; }
        public double? HesoluongCb { get; set; }
        public decimal? MucluongCb { get; set; }
        public string DieukhoanHd { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Status { get; set; }

        public virtual Chucvu MscvNavigation { get; set; }
        public virtual HosoNv MsnvNavigation { get; set; }
    }
}
