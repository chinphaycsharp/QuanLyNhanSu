using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Position;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Services
{
    public class PositionServiceImpl : IPositionService
    {
        private readonly QuanLyNhanSuContext _dbContext;

        public PositionServiceImpl(QuanLyNhanSuContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddPosition(AddPositionViewModel viewModel)
        {
            Chucvu chucvu = new Chucvu()
            {
                Mscv = viewModel.Mscv,
                TenCv = viewModel.TenCv,
                MotaCv = viewModel.MotaCv,
                Phucaptrachnhiem = viewModel.Phucaptrachnhiem,
                CreatedAt = DateTime.Now,
                Status =1
            };

            try
            {
                _dbContext.Chucvus.Add(chucvu);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> DeletePosition(string id)
        {
            var Chucvu = await _dbContext.Chucvus.FindAsync(id);
            Chucvu.Status = 0;
            try
            {
                _dbContext.Chucvus.Update(Chucvu);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<int> EditPosition(EditPositionViewModel viewModel)
        {
            Chucvu chucvu = await _dbContext.Chucvus.FindAsync(viewModel.Mscv);
            chucvu.TenCv = viewModel.TenCv;
            chucvu.MotaCv = viewModel.MotaCv;
            chucvu.Phucaptrachnhiem = viewModel.Phucaptrachnhiem;
            chucvu.UpdatedAt = DateTime.Now;
            chucvu.Status = 1;
            try
            {
                _dbContext.Chucvus.Update(chucvu);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public IQueryable<Chucvu> GetAllPostions(string search)
        {
            var Chucvus = _dbContext.Chucvus.Where(x=>x.Status == 1).AsQueryable();
            if (search == null || search == String.Empty)
            {
                return Chucvus.AsQueryable();
            }
            Chucvus = Chucvus.Where(x => x.Mscv.Contains(search) && x.Status == 1).AsQueryable();
            return Chucvus;
        }

        public async Task<EditPositionViewModel> GetPositionById(string id)
        {
            var chucvu = await _dbContext.Chucvus.FindAsync(id);
            EditPositionViewModel result = new EditPositionViewModel()
            {
                Mscv = chucvu.Mscv,
                MotaCv = chucvu.MotaCv,
                TenCv = chucvu.TenCv,
                Phucaptrachnhiem = chucvu.Phucaptrachnhiem,
            };
            return result;
        }
    }
}
