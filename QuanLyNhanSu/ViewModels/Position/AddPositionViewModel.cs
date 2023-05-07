using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.ViewModels.Position
{
    public class AddPositionViewModel
    {
        public string Mscv { get; set; }
        public string TenCv { get; set; }
        public string MotaCv { get; set; }
        public decimal? Phucaptrachnhiem { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
