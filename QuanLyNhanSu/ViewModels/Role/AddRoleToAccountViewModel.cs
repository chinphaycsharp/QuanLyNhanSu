using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace QuanLyNhanSu.ViewModels.Role
{
    public class AddRoleToAccountViewModel
    {
        public int Id { get; set; }
        public List<SelectListItem> drpRoles { get; set; }
        public string[] Roles { get; set; }
    }
}
