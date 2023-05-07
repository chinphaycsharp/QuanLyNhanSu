using System;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSu.ViewModels.Account
{
    public class AddAccountViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
