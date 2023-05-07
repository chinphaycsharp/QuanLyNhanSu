using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.RoleEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Services
{
    public class RoleEmployeeServiceImpl : IRoleEmployeeService
    {
        private readonly QuanLyNhanSuContext _dbContext;
        public RoleEmployeeServiceImpl(QuanLyNhanSuContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddRoleEmployee(AddRoleEmployeeViewModel viewModel)
        {
            QuyenNv quyenNv = new QuyenNv()
            {
                MaQuyen = viewModel.MaQuyen,
                id = viewModel.idAccount,
                status =1
            };
            try
            {
                _dbContext.QuyenNvs.Add(quyenNv);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> DeleteRoleEmployee(string maquyen)
        {
            var quyenNv = await _dbContext.QuyenNvs.FindAsync(maquyen);
            quyenNv.status = 0;
            try
            {
                _dbContext.QuyenNvs.Update(quyenNv);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> EditRoleEmployee(UpdateRoleEmployeeViewModel viewModel)
        {
            QuyenNv quyenNv = await _dbContext.QuyenNvs.FindAsync(viewModel.MaQuyen);
            quyenNv.MaQuyen = viewModel.MaQuyen;
            quyenNv.id = viewModel.idAccount;
            quyenNv.status = 1;
            try
            {
                _dbContext.QuyenNvs.Add(quyenNv);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<List<QuyenNv>> GetAllRoleEmployees()
        {
            return await _dbContext.QuyenNvs.Where(x=>x.status == 1).ToListAsync();
        }

        public async Task<List<RoleEmployeeViewModel>> GetRoleEmployeeByIdAccount(int idAccount)
        {
            var quyenNvs = await _dbContext.QuyenNvs.Where(x=>x.id == idAccount && x.status == 1).ToListAsync();
            var result = from x in quyenNvs
                         select new RoleEmployeeViewModel()
                         {
                             id = x.id,
                             MaQuyen = x.MaQuyen
                         };
            return result.ToList();
        }
    }
}
