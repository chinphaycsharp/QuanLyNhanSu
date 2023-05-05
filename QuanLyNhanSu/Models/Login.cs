using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyNhanSu.Models
{
    public partial class Login
    {
        public Login()
        {
            HosoNvs = new HashSet<HosoNv>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<HosoNv> HosoNvs { get; set; }
    }
}
