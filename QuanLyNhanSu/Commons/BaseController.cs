using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using QuanLyNhanSu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Commons
{
    public class BaseController : Controller
    {
        // GET: Admin/base
        public override void OnActionExecuting(ActionExecutingContext filerContext)
        {
            var sess = HttpContext.Session.GetString(commonConst.user_session);
            if (sess == null)
            {
                filerContext.Result = new RedirectToRouteResult
                    (new RouteValueDictionary(new { controller = "Token", action = "Index" }));
            }
            base.OnActionExecuting(filerContext);
        }
    }
}
