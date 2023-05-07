using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Contract;
using QuanLyNhanSu.ViewModels.Employee;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Interfaces
{
    public interface IContractService
    {
        IQueryable<Hopdongld> GetAllContract();
        Task<EditContractViewModel> GetContractById(string sohd);
        Task<int> AddContract(AddContractViewModel viewModel);
        Task<int> EditContract(EditContractViewModel viewModel);
        Task<int> DeleteContract(string sohd);
    }
}
