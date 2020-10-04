using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Com.MrIT.PublicSite.Controllers
{
    public class EnterpriseController : Controller
    {
        public IActionResult Listing()
        {
            ViewBag.Login = "OK";
            return View();
        }

        public IActionResult Register()
        {
            ViewBag.Login = "OK";
            return View();
        }

        public IActionResult Payment()
        {
            ViewBag.Login = "OK";
            return View();
        }
    }
}
