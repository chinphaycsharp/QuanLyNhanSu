using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Helpers;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IActionResult> Index(string search, int? pageNumber)
        {
            var roles = _roleService.GetAllRoles();
            int pageSize = 5;
            return View(await PaginatedList<Quyen>.CreateAsync(roles, pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddRoleViewModel model)
        {
            ValidateResult resultMaQuyen = model.MaQuyen.ValidateRole("MaQuyen", "") == null ? null : model.MaQuyen.ValidateRole("MaQuyen", "");
            ValidateResult resultMoTa = model.MoTa.ValidateRole("MoTa", "") == null ? null : model.MoTa.ValidateRole("MoTa", "");
            if (resultMaQuyen._isNull == false || resultMoTa._isNull == false)
            {
                ViewBag.resultMsnv = resultMaQuyen;
                ViewBag.resultMoTa = resultMoTa;
                return View();
            }
            var isSuccess = await _roleService.AddRole(model);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "Role");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var account = await _roleService.GetRoleById(id);
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRoleViewModel model)
        {
            ValidateResult resultMoTa = model.MoTa.ValidateRole("MoTa", "") == null ? null : model.MoTa.ValidateRole("MoTa", "");
            if (resultMoTa._isNull == false)
            {
                ViewBag.resultMoTa = resultMoTa;
                return View();
            }
            var isSuccess = await _roleService.EditRole(model);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "Role");
            }
            else
            {
                return View();
            }
        }

        public async Task<JsonResult> Delete(string id)
        {
            var isSuccess = await _roleService.DeleteRole(id);
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