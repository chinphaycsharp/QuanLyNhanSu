using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Services
{
    public class ContractServiceImpl : IContractService
    {
        private readonly QuanLyNhanSuContext _dbContext;
        public ContractServiceImpl(QuanLyNhanSuContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddContract(AddContractViewModel viewModel)
        {
            Hopdongld hopdongld = new Hopdongld()
            {
                SoHd = viewModel.SoHd,
                Mscv = viewModel.Mscv,
                Msnv = viewModel.Msnv,
                Tgianbatdau = viewModel.Tgianbatdau,
                Tgianketthuc = DateTime.Now.AddYears(1),
                HesoluongCb = viewModel.HesoluongCb,
                MucluongCb = viewModel.MucluongCb,
                DieukhoanHd = viewModel.DieukhoanHd,
                CreatedAt = DateTime.Now,
                Status = 1
            };
            try
            {
                _dbContext.Hopdonglds.Add(hopdongld);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> DeleteContract(string id)
        {
            var hd = await _dbContext.Hopdonglds.FindAsync(id);
            hd.Status = 0;
            try
            {
                _dbContext.Hopdonglds.Update(hd);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> EditContract(EditContractViewModel viewModel)
        {
            Hopdongld hopdongld = await _dbContext.Hopdonglds.FindAsync(viewModel.SoHd);
            hopdongld.SoHd = viewModel.SoHd;
            hopdongld.Mscv = viewModel.Mscv;
            hopdongld.Msnv = viewModel.Msnv;
            hopdongld.Tgianbatdau = viewModel.Tgianbatdau;
            hopdongld.Tgianketthuc = DateTime.Now.AddYears(1);
            hopdongld.HesoluongCb = viewModel.HesoluongCb;
            hopdongld.MucluongCb = viewModel.MucluongCb;
            hopdongld.DieukhoanHd = viewModel.DieukhoanHd;
            hopdongld.CreatedAt = DateTime.Now;
            hopdongld.Status = 1;
            try
            {
                _dbContext.Hopdonglds.Update(hopdongld);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public IQueryable<Hopdongld> GetAllContract()
        {   
            return _dbContext.Hopdonglds.Where(x=>x.Status == 1).AsQueryable();
        }

        public async Task<EditContractViewModel> GetContractByEmpId(string msnv)
        {
            var hd = await _dbContext.Hopdonglds.Where(x=>x.Msnv == msnv).FirstOrDefaultAsync();
            if(hd != null)
            {
                EditContractViewModel result = new EditContractViewModel()
                {
                    SoHd = hd.SoHd,
                    Mscv = hd.Mscv,
                    Msnv = hd.Msnv,
                    LoaiHd = hd.LoaiHd,
                    Tgianbatdau = hd.Tgianbatdau,
                    Tgianketthuc = hd.Tgianketthuc,
                    HesoluongCb = hd.HesoluongCb,
                    MucluongCb = hd.MucluongCb,
                    DieukhoanHd = hd.DieukhoanHd,
                };
                return result;
            }
            return default;
        }

        public async Task<EditContractViewModel> GetContractById(string sohd)
        {
            var hd = await _dbContext.Hopdonglds.FindAsync(sohd);
            EditContractViewModel result = new EditContractViewModel()
            {
                SoHd = sohd,
                Mscv = hd.Mscv,
                Msnv = hd.Msnv,
                LoaiHd = hd.LoaiHd,
                Tgianbatdau = hd.Tgianbatdau,
                Tgianketthuc = hd.Tgianketthuc,
                HesoluongCb = hd.HesoluongCb,
                MucluongCb = hd.MucluongCb,
                DieukhoanHd = hd.DieukhoanHd,
            };
            return result;
        }
    }
}
