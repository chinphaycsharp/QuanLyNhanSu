using Microsoft.AspNetCore.Mvc;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Helpers;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.ViewModels.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Controllers
{
    public class PositionController : BaseController
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService postionService)
        {
            _positionService = postionService;
        }

        public async Task<IActionResult> Index(string search, int? pageNumber)
        {
            var roles = _positionService.GetAllPostions(search);
            int pageSize = 5;
            return View(await PaginatedList<Chucvu>.CreateAsync(roles, pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddPositionViewModel model)
        {
            ValidateResult resultMscv = model.Mscv.ValidatePosition("Mscv") == null ? null : model.Mscv.ValidatePosition("Mscv");
            ValidateResult resultTenCv = model.TenCv.ValidatePosition("TenCv") == null ? null : model.TenCv.ValidatePosition("TenCv");
            ValidateResult resultMotaCv = model.MotaCv.ValidatePosition("MotaCv") == null ? null : model.MotaCv.ValidatePosition("MotaCv");
            ValidateResult resultPhucaptrachnhiem = model.Phucaptrachnhiem.ToString().ValidatePosition("Phucaptrachnhiem") == null ? null : model.Phucaptrachnhiem.ToString().ValidatePosition("Phucaptrachnhiem");
            if (resultMscv._isNull == false || resultTenCv._isNull == false || resultMotaCv._isNull == false || resultPhucaptrachnhiem._isNull == false)
            {
                ViewBag.resultMscv = resultMscv;
                ViewBag.resultTenCv = resultTenCv;
                ViewBag.resultMotaCv = resultMotaCv;
                ViewBag.resultPhucaptrachnhiem = resultPhucaptrachnhiem;
                return View();
            }
            model.CreateAt = DateTime.Now;
            var isSuccess = await _positionService.AddPosition(model);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "Position");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var account = await _positionService.GetPositionById(id);
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPositionViewModel model)
        {
            ValidateResult resultTenCv = model.TenCv.ValidatePosition("TenCv") == null ? null : model.TenCv.ValidatePosition("TenCv");
            ValidateResult resultMotaCv = model.MotaCv.ValidatePosition("MotaCv") == null ? null : model.MotaCv.ValidatePosition("MotaCv");
            ValidateResult resultPhucaptrachnhiem = model.Phucaptrachnhiem.ToString().ValidatePosition("Phucaptrachnhiem") == null ? null : model.Phucaptrachnhiem.ToString().ValidatePosition("Phucaptrachnhiem");
            if ( resultTenCv._isNull == false || resultMotaCv._isNull == false || resultPhucaptrachnhiem._isNull == false)
            {
                ViewBag.resultTenCv = resultTenCv;
                ViewBag.resultMotaCv = resultMotaCv;
                ViewBag.resultPhucaptrachnhiem = resultPhucaptrachnhiem;
                return View();
            }
            model.UpdatedAt = DateTime.Now;
            var isSuccess = await _positionService.EditPosition(model);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "Position");
            }
            else
            {
                return View();
            }
        }

        public async Task<JsonResult> Delete(string id)
        {
            var isSuccess = await _positionService.DeletePosition(id);
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
