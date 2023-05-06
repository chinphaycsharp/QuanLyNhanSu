using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Services
{
    public class ContractServiceImpl : IContractService
    {
        public Task<int> AddContract(AddContractViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteContract(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> EditContract(EditContractViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Hopdongld>> GetAllContract()
        {
            throw new System.NotImplementedException();
        }

        public Task<Hopdongld> GetContractById(string maHs)
        {
            throw new System.NotImplementedException();
        }
    }
}
