using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Services
{
    public class EmployeeServiceImpl : IEmployeeService
    {
        private readonly QuanLyNhanSuContext _dbContext;
        public EmployeeServiceImpl(QuanLyNhanSuContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddEmployee(AddEmployeeViewModel viewModel)
        {
            HosoNv nv = new HosoNv()
            {
                Msnv = viewModel.Msnv,
                Idlogin = viewModel.Idlogin,
                HotenNv = viewModel.HotenNv,
                Gioitinh = viewModel.Gioitinh,
                Ngaysinh = viewModel.Ngaysinh,
                QueQuan = viewModel.QueQuan,
                Sđt = viewModel.Sđt,
                SoCmtnd = viewModel.SoCmtnd,
                Ngaycap = viewModel.Ngaycap,
                Noicap = viewModel.Noicap,
                Điachithuongtru = viewModel.Điachithuongtru,
                CreatedAt = DateTime.Now
            };
            try
            {
                _dbContext.HosoNvs.Add(nv);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> DeleteEmployee(string id)
        {
            var employee = await _dbContext.HosoNvs.FindAsync(id);
            try
            {
                _dbContext.HosoNvs.Remove(employee);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> EditEmployee(EditEmployeeViewModel viewModel)
        {
            HosoNv nv = new HosoNv()
            {
                Msnv = viewModel.Msnv,
                Idlogin = viewModel.Idlogin,
                HotenNv = viewModel.HotenNv,
                Gioitinh = viewModel.Gioitinh,
                Ngaysinh = viewModel.Ngaysinh,
                QueQuan = viewModel.QueQuan,
                Sđt = viewModel.Sđt,
                SoCmtnd = viewModel.SoCmtnd,
                Ngaycap = viewModel.Ngaycap,
                Noicap = viewModel.Noicap,
                Điachithuongtru = viewModel.Điachithuongtru,
                CreatedAt = DateTime.Now
            };
            try
            {
                _dbContext.HosoNvs.Update(nv);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<List<HosoNv>> GetAllEmployees()
        {
            return await _dbContext.HosoNvs.ToListAsync();
        }

        public async Task<HosoNv> GetEmployeeById(string maHs)
        {
            return await _dbContext.HosoNvs.FindAsync(maHs);
        }
    }
}
