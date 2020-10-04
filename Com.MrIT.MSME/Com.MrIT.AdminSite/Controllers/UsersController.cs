using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Com.MrIT.Services;
using Com.MrIT.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Com.MrIT.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Com.MrIT.AdminSite.Filters;

namespace Com.MrIT.AdminSite.Controllers
{
    [MrITActionFilter]
    public class UsersController : Controller
    {
        private readonly IMrUserService _svsMrUser;
        private readonly IHttpContextAccessor _accessor;

        public UsersController(IMrUserService svsMrUser, IHttpContextAccessor accessor)
        {
            this._svsMrUser = svsMrUser;
            this._accessor = accessor;
        }

        #region Authentication
        [HttpGet]
        [ActionName("SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ActionName("SignIn")]
        public ActionResult SignIn(VmMrUser user)
        {
           
            HttpContext.Session.SetString("FullName", "Thant Sin Aung");

            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn", "Users");
        }
        #endregion

       
    }
}