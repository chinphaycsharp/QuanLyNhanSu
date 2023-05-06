using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Commons;

namespace QuanLyNhanSu.Controllers
{
    public class ContractController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
