using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Account;
using QuanLyNhanSu.ViewModels.Contract;
using QuanLyNhanSu.ViewModels.Role;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Interfaces
{
    public interface IAccountService
    {
        IQueryable<Login> GetAllAccounts(string search);
        Task<EditAccountViewModel> GetAccountById(int id);
        Task<int> AddAccount(AddAccountViewModel viewModel);
        Task<int> EditAccount(EditAccountViewModel viewModel);
        Task<int> DeleteAccount(int id);
        Task<int> AddRoleToAccount(AddRoleToAccountViewModel viewModel);
    }
}
