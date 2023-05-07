using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Helpers;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Contract;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Controllers
{
    public class ContractController : BaseController
    {
        private readonly IContractService _contractService;
        private readonly IEmployeeService _employeeService;
        private readonly IPositionService _positionService;
        public ContractController(IContractService contractService, IEmployeeService employeeService, IPositionService positionService)
        {
            _contractService = contractService;
            _employeeService = employeeService;
            _positionService = positionService;
        }

        public async Task<IActionResult> Index(string search, int? pageNumber)
        {
            var contracts = _contractService.GetAllContract();
            int pageSize = 1;
            return View(await PaginatedList<Hopdongld>.CreateAsync(contracts, pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.employees = _employeeService.GetAllEmployees(null);
            ViewBag.positions = _positionService.GetAllPostions(null);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddContractViewModel model)
        {
            ValidateResult resultSoHd = model.SoHd.ValidateContract("SoHd") == null ? null : model.SoHd.ValidateContract("username");
            ValidateResult resultMscv = model.Mscv.ValidateContract("Mscv") == null ? null : model.Mscv.ValidateContract("password");
            ValidateResult resultMsnv = model.Msnv.ValidateContract("Msnv") == null ? null : model.Msnv.ValidateContract("Msnv");
            ValidateResult resultLoaiHd = model.LoaiHd.ValidateContract("LoaiHd") == null ? null : model.LoaiHd.ValidateContract("LoaiHd");
            ValidateResult resultHesoluongCb = model.HesoluongCb.ToString().ValidateContract("HesoluongCb") == null ? null : model.HesoluongCb.ToString().ValidateContract("HesoluongCb");
            ValidateResult resultMucluongCb = model.MucluongCb.ToString().ValidateContract("MucluongCb") == null ? null : model.MucluongCb.ToString().ValidateContract("MucluongCb");
            ValidateResult DieukhoanHd = model.DieukhoanHd.ValidateContract("DieukhoanHd") == null ? null : model.DieukhoanHd.ValidateContract("DieukhoanHd");
            if (resultSoHd._isNull == false || resultMscv._isNull == false || resultMsnv._isNull == false || resultLoaiHd._isNull == false
                || resultHesoluongCb._isNull == false || resultMucluongCb._isNull == false || DieukhoanHd._isNull == false )
            {
                ViewBag.resultSoHd = resultSoHd;
                ViewBag.resultMscv = resultMscv;
                ViewBag.resultMsnv = resultMsnv;
                ViewBag.resultLoaiHd = resultLoaiHd;
                ViewBag.resultHesoluongCb = resultHesoluongCb;
                ViewBag.resultMucluongCb = resultMucluongCb;
                ViewBag.DieukhoanHd = DieukhoanHd;
                return View();
            }
            model.CreatedAt = System.DateTime.Now;
            var isSuccess = await _contractService.AddContract(model);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "Contract");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var account = await _contractService.GetContractById(id);
            ViewBag.employees = _employeeService.GetAllEmployees(null);
            ViewBag.positions = _positionService.GetAllPostions(null);
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditContractViewModel model)
        {
            ValidateResult resultMscv = model.Mscv.ValidateContract("Mscv") == null ? null : model.Mscv.ValidateContract("password");
            ValidateResult resultMsnv = model.Msnv.ValidateContract("Msnv") == null ? null : model.Msnv.ValidateContract("Msnv");
            ValidateResult resultLoaiHd = model.LoaiHd.ValidateContract("LoaiHd") == null ? null : model.LoaiHd.ValidateContract("LoaiHd");
            ValidateResult resultHesoluongCb = model.HesoluongCb.ToString().ValidateContract("HesoluongCb") == null ? null : model.HesoluongCb.ToString().ValidateContract("HesoluongCb");
            ValidateResult resultMucluongCb = model.MucluongCb.ToString().ValidateContract("MucluongCb") == null ? null : model.MucluongCb.ToString().ValidateContract("MucluongCb");
            ValidateResult DieukhoanHd = model.DieukhoanHd.ValidateContract("DieukhoanHd") == null ? null : model.DieukhoanHd.ValidateContract("DieukhoanHd");
            if (resultMscv._isNull == false || resultMsnv._isNull == false || resultLoaiHd._isNull == false
                || resultHesoluongCb._isNull == false || resultMucluongCb._isNull == false || DieukhoanHd._isNull == false)
            {
                ViewBag.resultMscv = resultMscv;
                ViewBag.resultMsnv = resultMsnv;
                ViewBag.resultLoaiHd = resultLoaiHd;
                ViewBag.resultHesoluongCb = resultHesoluongCb;
                ViewBag.resultMucluongCb = resultMucluongCb;
                ViewBag.DieukhoanHd = DieukhoanHd;
                return View();
            }
            model.UpdateAt = System.DateTime.Now;

            var isSuccess = await _contractService.EditContract(model);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "Contract");
            }
            else
            {
                return View();
            }
        }

        public async Task<JsonResult> Delete(string id)
        {
            var isSuccess = await _contractService.DeleteContract(id);
            if (isSuccess == 1)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}
