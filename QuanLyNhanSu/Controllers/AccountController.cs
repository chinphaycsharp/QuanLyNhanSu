using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Commons;

namespace QuanLyNhanSu.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
