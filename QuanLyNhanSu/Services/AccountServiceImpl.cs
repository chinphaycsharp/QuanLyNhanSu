using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Helpers;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Account;
using QuanLyNhanSu.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Services
{
    public class AccountServiceImpl : IAccountService
    {
        private readonly QuanLyNhanSuContext _dbContext;

        public AccountServiceImpl(QuanLyNhanSuContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAccount(AddAccountViewModel viewModel)
        {
            Login account = new Login()
            {
                Username = viewModel.Username,
                Password = EncryptionHelper.ToMD5(viewModel.Password),
                Email = viewModel.Email,
                CreatedAt = DateTime.Now,
                Status = 1
            };
            try
            {
                _dbContext.Logins.Add(account);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> AddRoleToAccount(AddRoleToAccountViewModel viewModel)
        {
            int isSuccess = 1;
            foreach (var role in viewModel.Roles)
            {
                isSuccess = -1;
                QuyenNv quyen = new QuyenNv()
                {
                    IdLogin = viewModel.Id,
                    MaQuyen = role,
                    Status = 1
                };

                try
                {
                    _dbContext.QuyenNvs.Add(quyen);
                    await _dbContext.SaveChangesAsync();
                    isSuccess = 1;
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return isSuccess;
        }

        public async Task<int> DeleteAccount(int id)
        {
            var account = await _dbContext.Logins.FindAsync(id);
            account.Status = 0;
            try
            {
                _dbContext.Logins.Update(account);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> EditAccount(EditAccountViewModel viewModel)
        {
            Login account = await _dbContext.Logins.FindAsync(viewModel.Id);
            account.Username = viewModel.Username;
            account.Password = EncryptionHelper.ToMD5(viewModel.Password);
            account.Email = viewModel.Email;
            account.UpdatedAt = DateTime.Now;
            account.Status = 1;
            try
            {
                _dbContext.Logins.Update(account);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<EditAccountViewModel> GetAccountById(int id)
        {
            var account = await _dbContext.Logins.FindAsync(id);
            EditAccountViewModel result = new EditAccountViewModel()
            {
                Username = account.Username,
                Password = account.Password,
                Email = account.Email,
                UpdatedAt = account.UpdatedAt
            };
            return result;
        }

        public IQueryable<Login> GetAllAccounts(string search)
        {
            var accounts = _dbContext.Logins.Where(x=>x.Status == 1).AsQueryable();
            if (search == null || search == String.Empty)
            {
                return accounts.AsQueryable();
            }
            accounts = accounts.Where(x => x.Username.Contains(search) && x.Status == 1).AsQueryable();
            return accounts;
        }
    }
}
