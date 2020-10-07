using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Com.MrIT.AdminSite.Controllers
{
    public class EnterpriseController : Controller
    {
        public IActionResult RegisteredListing()
        {
            return View();
        }

        public IActionResult UnregisteredList()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        
    }
}
