using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.RevenueEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Services
{
    public class RevenueEmployeeServiceImpl : IRevenueEmployeeService
    {
        private readonly QuanLyNhanSuContext _dbContext;

        public RevenueEmployeeServiceImpl(QuanLyNhanSuContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddRevenueEmployee(AddRevenueEmployeeViewModel viewModel)
        {
            DoanhthuNv doanhthuNv = new DoanhthuNv()
            {
                DoanhThu = viewModel.DoanhThu,
                Msnv = viewModel.Msnv,
                UpdatedAt = DateTime.Now,
                Status = 1
            };
            try
            {
                _dbContext.DoanhthuNvs.Add(doanhthuNv);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> DeleteRevenueEmployee(int id)
        {
            var revenueEmployee = await _dbContext.DoanhthuNvs.FindAsync(id);
            revenueEmployee.Status = 0;
            try
            {
                _dbContext.DoanhthuNvs.Update(revenueEmployee);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> EditRevenueEmployee(EditRevenueEmployeeViewModel viewModel)
        {
            var revenueEmployee = await _dbContext.DoanhthuNvs.FindAsync(viewModel.Ma);
            revenueEmployee.Status = 1;
            revenueEmployee.DoanhThu = viewModel.DoanhThu;
            revenueEmployee.Msnv = viewModel.Msnv;
            revenueEmployee.UpdatedAt = DateTime.Now;
            try
            {
                _dbContext.DoanhthuNvs.Update(revenueEmployee);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public IQueryable<RevenueEmployeeViewModel> GetAllRevenueEmployees()
        {
            var doanhthu = _dbContext.DoanhthuNvs.Where(x => x.Status == 1).ToList();
            var nvs = _dbContext.HosoNvs.Where(x => x.Status == 1).ToList();
            var result = from d in doanhthu
                         join nv in nvs on d.Msnv equals nv.Msnv
                         select new RevenueEmployeeViewModel()
                         {
                             Id = d.Ma,
                             Manv = d.Msnv,
                             Tennv = nv.HotenNv,
                             DoanhThu = d.DoanhThu.ToString(),
                             NgayChot = d.CreatedAt.ToString()
                         };
            return result.AsQueryable();
        }

        public async Task<List<RevenueEmployeeViewModel>> GetAllRevenueEmployeesNoPaging()
        {
            var doanhthu = await _dbContext.DoanhthuNvs.Where(x => x.Status == 1).ToListAsync();
            var nvs= await _dbContext.HosoNvs.Where(x=>x.Status == 1).ToListAsync();
            var result = from d in doanhthu join nv in nvs on d.Msnv equals nv.Msnv
                         select new RevenueEmployeeViewModel()
                         {
                             Id = d.Ma,
                             Manv = d.Msnv,
                             Tennv = nv.HotenNv,
                             DoanhThu = d.DoanhThu.ToString(),
                             NgayChot = d.CreatedAt.ToString()
                         };
            return result.ToList();
        }

        public async Task<EditRevenueEmployeeViewModel> GetRevenueEmployeeById(int id)
        {
            var revenueEmployee = await _dbContext.DoanhthuNvs.FindAsync(id);
            EditRevenueEmployeeViewModel reseult = new EditRevenueEmployeeViewModel()
            {
                Ma = id,
                Msnv = revenueEmployee.Msnv,
                DoanhThu = revenueEmployee.DoanhThu,
                Status = revenueEmployee.Status
            };
            return reseult;
        }
    }
}
