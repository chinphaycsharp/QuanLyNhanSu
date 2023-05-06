using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Controllers
{
    public class TokenController : Controller
    {
        private readonly IAuthService _authService;
        public TokenController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Auth(userLoginViewModel model)
        {
            var result = _authService.Auth(model.username,model.password);
            if (result == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index","Token");
        }
    }
}
