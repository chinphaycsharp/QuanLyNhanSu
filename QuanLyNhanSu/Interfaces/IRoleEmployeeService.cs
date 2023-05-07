using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.RoleEmployee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Interfaces
{
    public interface IRoleEmployeeService
    {
        Task<List<QuyenNv>> GetAllRoleEmployees();
        Task<List<RoleEmployeeViewModel>> GetRoleEmployeeByIdAccount(int idAccount);
        Task<int> AddRoleEmployee(AddRoleEmployeeViewModel viewModel);
        Task<int> EditRoleEmployee(UpdateRoleEmployeeViewModel viewModel);
        Task<int> DeleteRoleEmployee(string maquyen);
    }
}
