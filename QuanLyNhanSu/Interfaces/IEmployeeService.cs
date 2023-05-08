using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Employee;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Interfaces
{
    public interface IEmployeeService
    {
        IQueryable<HosoNv> GetAllEmployees(string search);
        Task<EditEmployeeViewModel> GetEmployeeById(string manv);
        Task<int> AddEmployee(AddEmployeeViewModel viewModel);
        Task<int> EditEmployee(EditEmployeeViewModel viewModel);
        Task<int> DeleteEmployee(string id);
        Task<int> AddAccount(string id, int Idlogin);
        Task<EditEmployeeViewModel> GetEmployeeByAccountId(int idAccount);
    }
}
