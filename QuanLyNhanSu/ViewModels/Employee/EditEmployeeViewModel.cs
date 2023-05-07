using System.ComponentModel.DataAnnotations;
using System;

namespace QuanLyNhanSu.ViewModels.Employee
{
    public class EditEmployeeViewModel
    {
        [Required]
        public string Msnv { get; set; }
        public int? Idlogin { get; set; }
        [Required]
        public string HotenNv { get; set; }
        [Required]
        public string Gioitinh { get; set; }
        public DateTime? Ngaysinh { get; set; }
        [Required]
        public string QueQuan { get; set; }
        [Required]
        public string Sđt { get; set; }
        [Required]
        public string SoCmtnd { get; set; }
        public DateTime? Ngaycap { get; set; }
        public string Noicap { get; set; }
        [Required]
        public string Điachithuongtru { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
