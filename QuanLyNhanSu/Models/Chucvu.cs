using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyNhanSu.Models
{
    public partial class Chucvu
    {
        public Chucvu()
        {
            Hopdonglds = new HashSet<Hopdongld>();
        }

        public string Mscv { get; set; }
        public string TenCv { get; set; }
        public string MotaCv { get; set; }
        public decimal? Phucaptrachnhiem { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Hopdongld> Hopdonglds { get; set; }
    }
}
