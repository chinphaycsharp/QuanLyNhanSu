using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.ViewModels.Position
{
    public class EditPositionViewModel
    {
        public string Mscv { get; set; }
        public string TenCv { get; set; }
        public string MotaCv { get; set; }
        public decimal? Phucaptrachnhiem { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
