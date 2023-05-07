using System;

namespace QuanLyNhanSu.ViewModels.Contract
{
    public class EditContractViewModel
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
        public DateTime? UpdateAt { get; set; }
    }
}
