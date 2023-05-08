using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Helpers;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Account;
using QuanLyNhanSu.ViewModels.Employee;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAccountService _accountService;
        public EmployeeController(IEmployeeService employeeService, IAccountService accountService)
        {
            _employeeService = employeeService;
            _accountService = accountService;
        }

        public async Task<IActionResult> Index(string search, int? pageNumber)
        {
            var employees = _employeeService.GetAllEmployees(search);
            int pageSize = 1;
            return View(await PaginatedList<HosoNv>.CreateAsync(employees, pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult AddAccount(string id)
        {
            ViewBag.accounts = _accountService.GetAllAccounts(null);
            AddAccountEmployeeViewModel model = new AddAccountEmployeeViewModel()
            {
                id = id,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount(AddAccountEmployeeViewModel model)
        {
            ValidateResult resultidLogin = model.idLogin.ToString().ValidateEmployee("idLogin", "") == null ? null : model.idLogin.ToString().ValidateEmployee("idLogin", "");

            if (resultidLogin._isNull == false)
            {
                ViewBag.resultidLogin = resultidLogin;
                return View();
            }
            var isSuccess = await _employeeService.AddAccount(model.id,model.idLogin);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEmployeeViewModel model)
        {
            ValidateResult resultMsnv = model.Msnv.ValidateEmployee("Msnv", "") == null ? null : model.Msnv.ValidateEmployee("Msnv", "");
            ValidateResult resultHotenNv = model.HotenNv.ValidateEmployee("HotenNv", "") == null ? null : model.HotenNv.ValidateEmployee("HotenNv", "");
            ValidateResult resultGioitinh = model.Gioitinh.ValidateEmployee("Gioitinh", "") == null ? null : model.Gioitinh.ValidateEmployee("", "");
            ValidateResult resultQueQuan = model.QueQuan.ValidateEmployee("QueQuan", "") == null ? null : model.QueQuan.ValidateEmployee("QueQuan", "");
            ValidateResult resultSđt = model.Sđt.ValidateEmployee("Sđt", "") == null ? null : model.Sđt.ValidateEmployee("Sđt", "");
            ValidateResult resultSoCmtnd = model.SoCmtnd.ValidateEmployee("SoCmtnd", "") == null ? null : model.SoCmtnd.ValidateEmployee("SoCmtnd", "");
            ValidateResult resultĐiachithuongtru = model.Điachithuongtru.ValidateEmployee("Điachithuongtru", "") == null ? null : model.Điachithuongtru.ValidateEmployee("Điachithuongtru", "");
            if (resultMsnv._isNull == false || resultHotenNv._isNull == false || resultGioitinh._isNull == false || resultQueQuan._isNull == false
                || resultSđt._isNull == false || resultSoCmtnd._isNull == false || resultĐiachithuongtru._isNull == false)
            {
                ViewBag.resultMsnv = resultMsnv;
                ViewBag.resultHotenNv = resultHotenNv;
                ViewBag.resultGioitinh = resultGioitinh;
                ViewBag.resultQueQuan = resultQueQuan;
                ViewBag.resultSđt = resultSđt;
                ViewBag.resultSoCmtnd = resultSoCmtnd;
                ViewBag.resultĐiachithuongtru = resultĐiachithuongtru;
                return View();
            }
            model.CreatedAt = System.DateTime.Now;
            var isSuccess = await _employeeService.AddEmployee(model);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var account = await _employeeService.GetEmployeeById(id);
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployeeViewModel model)
        {
            ValidateResult resultHotenNv = model.HotenNv.ValidateEmployee("HotenNv", "") == null ? null : model.HotenNv.ValidateEmployee("HotenNv", "");
            ValidateResult resultGioitinh = model.Gioitinh.ValidateEmployee("Gioitinh", "") == null ? null : model.Gioitinh.ValidateEmployee("", "");
            ValidateResult resultQueQuan = model.QueQuan.ValidateEmployee("QueQuan", "") == null ? null : model.QueQuan.ValidateEmployee("QueQuan", "");
            ValidateResult resultSđt = model.Sđt.ValidateEmployee("Sđt", "") == null ? null : model.Sđt.ValidateEmployee("Sđt", "");
            ValidateResult resultSoCmtnd = model.SoCmtnd.ValidateEmployee("SoCmtnd", "") == null ? null : model.SoCmtnd.ValidateEmployee("SoCmtnd", "");
            ValidateResult resultĐiachithuongtru = model.Điachithuongtru.ValidateEmployee("Điachithuongtru", "") == null ? null : model.Điachithuongtru.ValidateEmployee("Điachithuongtru", "");
            if ( resultHotenNv._isNull == false || resultGioitinh._isNull == false || resultQueQuan._isNull == false
                || resultSđt._isNull == false || resultSoCmtnd._isNull == false || resultĐiachithuongtru._isNull == false)
            {

                ViewBag.resultHotenNv = resultHotenNv;
                ViewBag.resultGioitinh = resultGioitinh;
                ViewBag.resultQueQuan = resultQueQuan;
                ViewBag.resultSđt = resultSđt;
                ViewBag.resultSoCmtnd = resultSoCmtnd;
                ViewBag.resultĐiachithuongtru = resultĐiachithuongtru;
                return View();
            }
            model.UpdatedAt = System.DateTime.Now;

            var isSuccess = await _employeeService.EditEmployee(model);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var account = await _employeeService.GetEmployeeById(id);
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Detail(EditEmployeeViewModel model)
        {
            ValidateResult resultHotenNv = model.HotenNv.ValidateEmployee("HotenNv", "") == null ? null : model.HotenNv.ValidateEmployee("HotenNv", "");
            ValidateResult resultGioitinh = model.Gioitinh.ValidateEmployee("Gioitinh", "") == null ? null : model.Gioitinh.ValidateEmployee("", "");
            ValidateResult resultQueQuan = model.QueQuan.ValidateEmployee("QueQuan", "") == null ? null : model.QueQuan.ValidateEmployee("QueQuan", "");
            ValidateResult resultSđt = model.Sđt.ValidateEmployee("Sđt", "") == null ? null : model.Sđt.ValidateEmployee("Sđt", "");
            ValidateResult resultSoCmtnd = model.SoCmtnd.ValidateEmployee("SoCmtnd", "") == null ? null : model.SoCmtnd.ValidateEmployee("SoCmtnd", "");
            ValidateResult resultĐiachithuongtru = model.Điachithuongtru.ValidateEmployee("Điachithuongtru", "") == null ? null : model.Điachithuongtru.ValidateEmployee("Điachithuongtru", "");
            if (resultHotenNv._isNull == false || resultGioitinh._isNull == false || resultQueQuan._isNull == false
                || resultSđt._isNull == false || resultSoCmtnd._isNull == false || resultĐiachithuongtru._isNull == false)
            {

                ViewBag.resultHotenNv = resultHotenNv;
                ViewBag.resultGioitinh = resultGioitinh;
                ViewBag.resultQueQuan = resultQueQuan;
                ViewBag.resultSđt = resultSđt;
                ViewBag.resultSoCmtnd = resultSoCmtnd;
                ViewBag.resultĐiachithuongtru = resultĐiachithuongtru;
                return View();
            }
            model.UpdatedAt = System.DateTime.Now;

            var isSuccess = await _employeeService.EditEmployee(model);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View();
            }
        }

        public async Task<JsonResult> Delete(string id)
        {
            var isSuccess = await _employeeService.DeleteEmployee(id);
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
