﻿using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Commons;

namespace QuanLyNhanSu.Controllers
{
    public class EmployeeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
