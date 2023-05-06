using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Services
{
    public class AccountServiceImpl : IAccountService
    {
        public Task<int> AddAccount(AddAccountViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteAccount(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> EditAccount(EditAccountViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<Login> GetAccountById(string maHs)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Login>> GetAllAccounts()
        {
            throw new System.NotImplementedException();
        }
    }
}
