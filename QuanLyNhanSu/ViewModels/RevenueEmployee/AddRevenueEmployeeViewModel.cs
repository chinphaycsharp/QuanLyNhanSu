﻿using System;

namespace QuanLyNhanSu.ViewModels.RevenueEmployee
{
    public class AddRevenueEmployeeViewModel
    {
        public int Ma { get; set; }
        public string Msnv { get; set; }
        public decimal DoanhThu { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? Status { get; set; }
    }
}
