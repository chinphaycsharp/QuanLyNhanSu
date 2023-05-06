using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Commons;

namespace QuanLyNhanSu.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
