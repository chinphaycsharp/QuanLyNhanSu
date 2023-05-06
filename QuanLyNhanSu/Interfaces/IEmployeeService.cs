using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<HosoNv>> GetAllEmployees();
        Task<HosoNv> GetEmployeeById(string maHs);
        Task<int> AddEmployee(AddEmployeeViewModel viewModel);
        Task<int> EditEmployee(EditEmployeeViewModel viewModel);
        Task<int> DeleteEmployee(string id);
    }
}
