using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Account;
using QuanLyNhanSu.ViewModels.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Interfaces
{
    public interface IAccountService
    {
        Task<List<Login>> GetAllAccounts();
        Task<Login> GetAccountById(string maHs);
        Task<int> AddAccount(AddAccountViewModel viewModel);
        Task<int> EditAccount(EditAccountViewModel viewModel);
        Task<int> DeleteAccount(string id);
    }
}
