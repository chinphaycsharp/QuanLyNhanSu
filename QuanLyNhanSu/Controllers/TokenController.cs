using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.ViewModels.Login;
using System;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Controllers
{
    public class TokenController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IRoleEmployeeService _roleEmployeeService;
        public TokenController(IAuthService authService, IRoleEmployeeService roleEmployeeService)
        {
            _authService = authService;
            _roleEmployeeService = roleEmployeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Auth(userLoginViewModel model)
        {
            if (model.password == null || model.username == null)
            {
                ViewBag.error = "Không được để trống trường này";
                return View("Index");
            }
            var result = _authService.Auth(model.username, model.password);
            if (result != null)
            {
                var roles = await _roleEmployeeService.GetRoleEmployeeByIdAccount(result.Id);
                try
                {
                    string json = HttpContext.Session.GetString(commonConst.user_session);
                    var userLogin = new userViewModel()
                    {
                        userID = result.Id,
                        userName = model.username,
                        roles = roles
                    };

                    string jsonSave = JsonConvert.SerializeObject(userLogin);
                    HttpContext.Session.SetString(commonConst.user_session, jsonSave);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
            else
            {
                return RedirectToAction("Index", "Token");
            }
        }

        public IActionResult Logout()
        {
            if(HttpContext.Session.GetString(commonConst.user_session) != null)
            {
                HttpContext.Session.Clear();
            }
            return RedirectToAction("Index");
        }
    }
}
