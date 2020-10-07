using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Com.MrIT.AdminSite.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult CheckingTask()
        {
            return View();
        }


        public IActionResult ApprovalTask()
        {
            return View();
        }
    }
}
