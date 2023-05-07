using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Commons;

namespace QuanLyNhanSu.Controllers
{
    public class RoleEmployeeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
