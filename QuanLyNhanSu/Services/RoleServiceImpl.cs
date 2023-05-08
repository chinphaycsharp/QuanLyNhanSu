using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Services
{
    public class RoleServiceImpl : IRoleService
    {
        private readonly QuanLyNhanSuContext _dbContext;
        public RoleServiceImpl(QuanLyNhanSuContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddRole(AddRoleViewModel viewModel)
        {
            Quyen quyen = new Quyen()
            {
                MaQuyen = viewModel.MaQuyen,
                MoTa = viewModel.MoTa,
                Status = 1
            };
            try
            {
                _dbContext.Quyens.Add(quyen);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> DeleteRole(string maquyen)
        {
            var quyen = await _dbContext.Quyens.FindAsync(maquyen);
            quyen.Status = 0;
            try
            {
                _dbContext.Quyens.Update(quyen);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> EditRole(EditRoleViewModel viewModel)
        {
            Quyen quyen = await _dbContext.Quyens.FindAsync(viewModel.MaQuyen);
            quyen.MaQuyen = viewModel.MaQuyen;
            quyen.MoTa = viewModel.MoTa;
            quyen.Status = 1;
            try
            {
                _dbContext.Quyens.Update(quyen);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public IQueryable<Quyen> GetAllRoles()
        {
            return _dbContext.Quyens.Where(x => x.Status == 1).AsQueryable();
        }

        public async Task<EditRoleViewModel> GetRoleById(string maquyen)
        {
            var quyen = await _dbContext.Quyens.FindAsync(maquyen);
            EditRoleViewModel model = new EditRoleViewModel()
            {
                MaQuyen = quyen.MaQuyen,
                MoTa = quyen.MoTa
            };
            return model;
        }
    }
}
