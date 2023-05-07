using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Interfaces
{
    public interface IPositionService
    {
        IQueryable<Chucvu> GetAllPostions(string search);
        Task<EditPositionViewModel> GetPositionById(string id);
        Task<int> AddPosition(AddPositionViewModel viewModel);
        Task<int> EditPosition(EditPositionViewModel viewModel);
        Task<int> DeletePosition(string id);
    }
}
