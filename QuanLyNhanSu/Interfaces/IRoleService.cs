using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Role;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Interfaces
{
    public interface IRoleService
    {
        IQueryable<Quyen> GetAllRoles();
        Task<EditRoleViewModel> GetRoleById(string maquyen);
        Task<int> AddRole(AddRoleViewModel viewModel);
        Task<int> EditRole(EditRoleViewModel viewModel);
        Task<int> DeleteRole(string maquyen);
    }
}
