using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Helpers;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Account;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index(string search, int? pageNumber)
        {
            var accounts = _accountService.GetAllAccounts(search);
            int pageSize = 1;
            return View(await PaginatedList<Login>.CreateAsync(accounts.AsQueryable(), pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddAccountViewModel model)
        {
            ValidateResult resultUsername = model.Username.ValidateAccount("username", "") == null ? null : model.Username.ValidateAccount("username", "");
            ValidateResult resultPassword = model.Password.ValidateAccount("password", "") == null ? null : model.Password.ValidateAccount("password", "");
            ValidateResult resultComfirmPass = model.Password.ValidateAccount("", model.ConfirmPassword) == null ? null : model.Password.ValidateAccount("", model.ConfirmPassword);
            ValidateResult resultEmail = model.Email.ValidateAccount("email", "") == null ? null : model.Email.ValidateAccount("email", "");
            if(resultUsername._isNull == false || resultPassword._isNull == false || resultComfirmPass._isNull == false || resultEmail._isNull == false)
            {
                ViewBag.resultUsername = resultUsername;
                ViewBag.resultPassword = resultPassword;
                ViewBag.resultComfirmPass = resultComfirmPass;
                ViewBag.resultEmail = resultEmail;
                return View();
            }
            model.CreatedAt = System.DateTime.Now;
            var isSuccess = await _accountService.AddAccount(model);
            if(isSuccess == 1)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var account = await _accountService.GetAccountById(id);
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAccountViewModel model)
        {
            ValidateResult resultUsername = model.Username.ValidateAccount("username", "") == null ? null : model.Username.ValidateAccount("username", "");
            ValidateResult resultPassword = model.Password.ValidateAccount("password", "") == null ? null : model.Password.ValidateAccount("password", "");
            ValidateResult resultComfirmPass = model.Password.ValidateAccount("", model.ConfirmPassword) == null ? null : model.Password.ValidateAccount("", model.ConfirmPassword);
            ValidateResult resultEmail = model.Email.ValidateAccount("email", "") == null ? null : model.Email.ValidateAccount("email", "");
            if (resultUsername._isNull == false || resultPassword._isNull == false || resultComfirmPass._isNull == false || resultEmail._isNull == false)
            {
                ViewBag.resultUsername = resultUsername;
                ViewBag.resultPassword = resultPassword;
                ViewBag.resultComfirmPass = resultComfirmPass;
                ViewBag.resultEmail = resultEmail;
                return View();
            }
            model.UpdatedAt = System.DateTime.Now;

            var isSuccess = await _accountService.EditAccount(model);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                return View();
            }
        }

        public async Task<JsonResult> Delete(int id)
        {
            var isSuccess = await _accountService.DeleteAccount(id);
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
