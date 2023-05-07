using System.ComponentModel.DataAnnotations;

namespace QuanLyNhanSu.ViewModels.Login
{
    public class userLoginViewModel
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }
        public string email { get; set; }
    }
}
