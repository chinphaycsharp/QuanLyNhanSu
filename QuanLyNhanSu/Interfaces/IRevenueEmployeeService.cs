using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.RevenueEmployee;
using QuanLyNhanSu.ViewModels.Role;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Interfaces
{
    public interface IRevenueEmployeeService
    {
        IQueryable<ViewDoanhthuNv> GetAllRevenueEmployees();
        Task<List<RevenueEmployeeViewModel>> GetAllRevenueEmployeesNoPaging();
        Task<EditRevenueEmployeeViewModel> GetRevenueEmployeeById(int id);
        Task<int> AddRevenueEmployee(AddRevenueEmployeeViewModel viewModel);
        Task<int> EditRevenueEmployee(EditRevenueEmployeeViewModel viewModel);
        Task<int> DeleteRevenueEmployee(int id);
    }
}
