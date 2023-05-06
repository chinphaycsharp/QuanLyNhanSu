using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Contract;
using QuanLyNhanSu.ViewModels.Employee;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Interfaces
{
    public interface IContractService
    {
        Task<List<Hopdongld>> GetAllContract();
        Task<Hopdongld> GetContractById(string maHs);
        Task<int> AddContract(AddContractViewModel viewModel);
        Task<int> EditContract(EditContractViewModel viewModel);
        Task<int> DeleteContract(string id);
    }
}
