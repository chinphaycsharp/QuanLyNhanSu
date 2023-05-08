using System;

namespace QuanLyNhanSu.ViewModels.RevenueEmployee
{
    public class EditRevenueEmployeeViewModel
    {
        public int Ma { get; set; }
        public string Msnv { get; set; }
        public decimal DoanhThu { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Status { get; set; }
    }
}
