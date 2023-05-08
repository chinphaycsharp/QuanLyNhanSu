using iText.Html2pdf;
using iText.IO.Source;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Commons;
using QuanLyNhanSu.Helpers;
using QuanLyNhanSu.Interfaces;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;
using QuanLyNhanSu.ViewModels.RevenueEmployee;
using QuanLyNhanSu.ViewModels.Role;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Controllers
{
    public class RevenueEmployeeController : BaseController
    {
        private readonly IRevenueEmployeeService _revenueEmployeeService;
        private readonly IEmployeeService _employeeService;
        public RevenueEmployeeController(IRevenueEmployeeService revenueEmployeeService, IEmployeeService employeeService)
        {
            _revenueEmployeeService = revenueEmployeeService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(string search, int? pageNumber)
        {
            var revenueEmployees =  _revenueEmployeeService.GetAllRevenueEmployees();
            int pageSize = 5;
            return View(await PaginatedList<ViewDoanhthuNv>.CreateAsync(revenueEmployees, pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.employees =  _employeeService.GetAllEmployees(null);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddRevenueEmployeeViewModel model)
        {
            ValidateResult resultMsnv = model.Msnv.ValidateRevenueEmployee("Msnv") == null ? null : model.Msnv.ValidateRevenueEmployee("Msnv");
            ValidateResult resultDoanhThu = model.DoanhThu.ToString().ValidateRevenueEmployee("DoanhThu") == null ? null : model.DoanhThu.ToString().ValidateRevenueEmployee("DoanhThu");
            if (resultMsnv._isNull == false || resultDoanhThu._isNull == false)
            {
                ViewBag.resultMsnv = resultMsnv;
                ViewBag.resultDoanhThu = resultDoanhThu;
                return View();
            }
            var isSuccess = await _revenueEmployeeService.AddRevenueEmployee(model);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "RevenueEmployee");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var account = await _revenueEmployeeService.GetRevenueEmployeeById(id);
            ViewBag.employees = _employeeService.GetAllEmployees(null);
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRevenueEmployeeViewModel model)
        {
            ValidateResult resultMsnv = model.Msnv.ValidateRevenueEmployee("Msnv") == null ? null : model.Msnv.ValidateRevenueEmployee("Msnv");
            ValidateResult resultDoanhThu = model.DoanhThu.ToString().ValidateRevenueEmployee("DoanhThu") == null ? null : model.DoanhThu.ToString().ValidateRevenueEmployee("DoanhThu");
            if (resultMsnv._isNull == false || resultDoanhThu._isNull == false)
            {
                ViewBag.resultMsnv = resultMsnv;
                ViewBag.resultDoanhThu = resultDoanhThu;
                return View();
            }
            var isSuccess = await _revenueEmployeeService.EditRevenueEmployee(model);
            if (isSuccess == 1)
            {
                return RedirectToAction("Index", "RevenueEmployee");
            }
            else
            {
                return View();
            }
        }

        public async Task<JsonResult> Delete(int id)
        {
            var isSuccess = await _revenueEmployeeService.DeleteRevenueEmployee(id);
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

        [HttpPost]
        public async Task<FileResult> Export()
        {
            List<RevenueEmployeeViewModel> result = await _revenueEmployeeService.GetAllRevenueEmployeesNoPaging();
            List<object> customers = (from customer in result
                                      select new[] {
                                      customer.Manv,
                                      customer.Tennv,
                                      customer.DoanhThu,
                                      customer.NgayChot
                                 }).ToList<object>();
            //Building an HTML string.
            StringBuilder sb = new StringBuilder();

            //Table start.
            sb.Append("<table border='1' cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-family: Arial; font-size: 10pt;'>");

            //Building the Header row.
            sb.Append("<tr>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>CustomerID</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>ContactName</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>City</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Country</th>");
            sb.Append("</tr>");

            //Building the Data rows.
            for (int i = 0; i < customers.Count; i++)
            {
                string[] customer = (string[])customers[i];
                sb.Append("<tr>");
                for (int j = 0; j < customer.Length; j++)
                {
                    //Append data.
                    sb.Append("<td style='border: 1px solid #ccc'>");
                    sb.Append(customer[j]);
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }

            //Table end.
            sb.Append("</table>");

            using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(sb.ToString())))
            {
                ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
                PdfWriter writer = new PdfWriter(byteArrayOutputStream);
                PdfDocument pdfDocument = new PdfDocument(writer);
                pdfDocument.SetDefaultPageSize(PageSize.A4);
                HtmlConverter.ConvertToPdf(stream, pdfDocument);
                pdfDocument.Close();
                return File(byteArrayOutputStream.ToArray(), "application/pdf", "BaoCaoDoanhThu.pdf");
            }
        }
    }
}
