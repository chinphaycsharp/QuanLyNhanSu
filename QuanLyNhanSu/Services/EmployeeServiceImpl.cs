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

        public async Task<int> AddAccount(string id, int Idlogin)
        {
            var employee = await _dbContext.HosoNvs.FindAsync(id);
            employee.Status = 1;
            employee.Idlogin = Idlogin;
            try
            {
                _dbContext.HosoNvs.Update(employee);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
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
                CreatedAt = DateTime.Now,
                Status = 1
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
            employee.Status = 0;
            try
            {
                _dbContext.HosoNvs.Update(employee);
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
            HosoNv nv = await _dbContext.HosoNvs.FindAsync(viewModel.Msnv);
            nv.Msnv = viewModel.Msnv;
            nv.Idlogin = viewModel.Idlogin;
            nv.HotenNv = viewModel.HotenNv;
            nv.Gioitinh = viewModel.Gioitinh;
            nv.Ngaysinh = viewModel.Ngaysinh;
            nv.QueQuan = viewModel.QueQuan;
            nv.Sđt = viewModel.Sđt;
            nv.SoCmtnd = viewModel.SoCmtnd;
            nv.Ngaycap = viewModel.Ngaycap;
            nv.Noicap = viewModel.Noicap;
            nv.Điachithuongtru = viewModel.Điachithuongtru;
            nv.UpdatedAt = DateTime.Now;
            nv.Status = 1;
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

        public IQueryable<HosoNv> GetAllEmployees(string search)
        {
            var employees = _dbContext.HosoNvs.Where(x=>x.Status == 1).AsQueryable();
            if (search == null || search == String.Empty)
            {
                return employees.AsQueryable();
            }
            employees = employees.Where(x => x.Msnv.Contains(search) && x.Status == 1).AsQueryable();
            return employees;
        }

        public async Task<EditEmployeeViewModel> GetEmployeeByAccountId(int idAccount)
        {
            var employee = await _dbContext.HosoNvs.Where(x=>x.Idlogin == idAccount).FirstOrDefaultAsync();
            if(employee != null)
            {
                EditEmployeeViewModel result = new EditEmployeeViewModel()
                {
                    Msnv = employee.Msnv,
                    HotenNv = employee.HotenNv,
                    Gioitinh = employee.Gioitinh,
                    Ngaysinh = employee.Ngaysinh,
                    QueQuan = employee.QueQuan,
                    Sđt = employee.Sđt,
                    SoCmtnd = employee.SoCmtnd,
                    Ngaycap = employee.Ngaycap,
                    Noicap = employee.Noicap,
                    Điachithuongtru = employee.Điachithuongtru
                };
                return result;
            }

            return default;
        }

        public async Task<EditEmployeeViewModel> GetEmployeeById(string manv)
        {
            var employee = await _dbContext.HosoNvs.FindAsync(manv);
            if(employee != null)
            {
                EditEmployeeViewModel result = new EditEmployeeViewModel()
                {
                    Msnv = employee.Msnv,
                    Idlogin = employee.Idlogin,
                    HotenNv = employee.HotenNv,
                    Gioitinh = employee.Gioitinh,
                    Ngaysinh = employee.Ngaysinh,
                    QueQuan = employee.QueQuan,
                    Sđt = employee.Sđt,
                    SoCmtnd = employee.SoCmtnd,
                    Ngaycap = employee.Ngaycap,
                    Noicap = employee.Noicap,
                    Điachithuongtru = employee.Điachithuongtru
                };
                return result;
            }
            return default;
        }
    }
}
