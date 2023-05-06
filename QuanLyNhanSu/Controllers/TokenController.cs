using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanLyNhanSu.Commons;
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

        public IActionResult Auth(string username, string password)
        {
            var result = _authService.Auth(username,password);
            if (result != null)
            {
                try
                {
                    string json = HttpContext.Session.GetString(commonConst.user_session);
                    var userLogin = new
                    {
                        id = result.Id,
                        username = username,
                    };

                    string jsonSave = JsonConvert.SerializeObject(userLogin);
                    HttpContext.Session.SetString(commonConst.user_session, jsonSave);
                    return RedirectToAction("Index", "Home");
                }
                catch(Exception ex)
                {
                    return View(ex.Message);
                }
            }
            else
            {
                return RedirectToAction("Index", "Token");
            }
        }
    }
}
