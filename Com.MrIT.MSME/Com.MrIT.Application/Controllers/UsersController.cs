using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Com.MrIT.App.Filters;
using Com.MrIT.Common;
using Com.MrIT.Services;
using Com.MrIT.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Com.MrIT.PublicSite.Controllers
{

    public class UsersController : Controller
    {
        private readonly IEmailService _svsEmail;
        private readonly IMrUserService _svsUser;
        private readonly IHttpContextAccessor _accessor;

        public UsersController(IMrUserService svsUser, IEmailService svsEmail, IHttpContextAccessor accessor)
        {
            this._svsUser = svsUser;
            this._svsEmail = svsEmail;
            this._accessor = accessor;
        }

        #region Authentication
        [MrITActionFilter]
        [HttpGet]
        [ActionName("SignIn")]
        public IActionResult SignIn()
        {
            var currentUrl = HttpContext.Request.Query["currenturl"].ToString();
            

            ViewBag.CurrentUrl = "";
            if (!string.IsNullOrEmpty(currentUrl))
            {
                ViewBag.CurrentUrl = currentUrl;
                TempData["CurrentUrl"] = currentUrl;
            }

            return View();
        }

        [HttpPost]
        [ActionName("SignIn")]
        public IActionResult SignIn(VmMrUser user)
        {
            return RedirectToAction("ConfirmOTP", "Users");
        }

        public ActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn", "Users");
        }

        [HttpGet]
        [ActionName("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Register")]
        public IActionResult Register(VmSysUser user)
        {          
            return RedirectToAction("ConfirmOTP", "Users");
        }

        [HttpGet]
        [ActionName("ConfirmOTP")]
        public IActionResult ConfirmOTP()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ConfirmOTP")]
        public IActionResult ConfirmOTP(VmUserOtp vmUserOTP)
        {
            
            return RedirectToAction("Listing", "Enterprise");
        }

        [HttpGet]
        [ActionName("SuccessfulRegistration")]
        public IActionResult SuccessfulRegistration()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CheckUserForRegister(string Email, string MobileNo)
        {
            var result =  _svsUser.CheckUserForRegister(Email.EmptyIfNull(),"B", MobileNo);

            return Json(result);
        }
        #endregion

        #region Account Setting

        [MrITActionFilter]
        public IActionResult Profile()
        {
            try
            {
                int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
                var result = _svsUser.GetMrUserByID(userID);

                return View(result);
            }
            catch (Exception ex)
            {
                //string currenturl = Request.Scheme + "://" + Request.Host.Value + Request.Path.Value + Request.QueryString.Value;
                //string user = "admin";
                //var userName = HttpContext.Session.GetString("UserName");
                //if (!string.IsNullOrEmpty(userName))
                //{
                //    user = userName;
                //}
                //_svsEmail.InsertErrorAndEmail(ex, user, currenturl);

                return RedirectToAction("SystemIssue", "Errors", new { message = System.Web.HttpUtility.UrlEncode(ex.Message) });
            }
        }

        [MrITActionFilter]
        public IActionResult ProfileEdit()
        {
            try
            {
                int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
                var result = _svsUser.GetMrUserByID(userID);

                return View(result);
            }
            catch (Exception ex)
            {
                //string currenturl = Request.Scheme + "://" + Request.Host.Value + Request.Path.Value + Request.QueryString.Value;
                //string user = "admin";
                //var userName = HttpContext.Session.GetString("UserName");
                //if (!string.IsNullOrEmpty(userName))
                //{
                //    user = userName;
                //}
                // _svsEmail.InsertErrorAndEmail(ex, user, currenturl);

                return RedirectToAction("SystemIssue", "Errors", new { message = System.Web.HttpUtility.UrlEncode(ex.Message) });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProfileEdit(VmMrUser vmMruser)
        {
            try
            {
                vmMruser.ModifiedBy = vmMruser.FullName;

                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    if (Request.Form.Files[i].Length > 0)
                    {
                        if (Request.Form.Files[i].Name.ToLower() == "file_ProfileImage")
                        {
                            vmMruser.ProfileImage = ConvertFiletoBytes(Request.Form.Files[i]);
                        }
                    }
                }

                if (vmMruser.ProfileImage != null)
                {
                    HttpContext.Session.SetString("UserProfile", Convert.ToBase64String(vmMruser.ProfileImage).ToString());
                }
                vmMruser.ID = Convert.ToInt32(Md5.Decrypt(vmMruser.EncryptId));
                vmMruser.Active = vmMruser.SystemActive = true;

                var result = _svsUser.UpdateMrUser(vmMruser);
                TempData["MessageToUser"] = result.MessageToUser;
                TempData["Pass"] = vmMruser.Password;
                if (!result.IsSuccess)
                {
                    return RedirectToAction("SystemIssue", "Errors", new { message = HttpUtility.UrlEncode(result.MessageToUser) });
                }


                return RedirectToAction("Profile", "Users");
            }
            catch (Exception ex)
            {
                //string currenturl = Request.Scheme + "://" + Request.Host.Value + Request.Path.Value + Request.QueryString.Value;
                //string user = "admin";
                //var userName = HttpContext.Session.GetString("UserName");
                //if (!string.IsNullOrEmpty(userName))
                //{
                //    user = userName;
                //}
                //_svsEmail.InsertErrorAndEmail(ex, user, currenturl);

                return RedirectToAction("SystemIssue", "Errors", new { message = System.Web.HttpUtility.UrlEncode(ex.Message) });
            }
        }

        public JsonResult DisableAccount(string Password)
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            var result = _svsUser.DisableAccount(userID, Password, "C");

            return Json(result);
        }

        public JsonResult ChangePassword(string CurrentPassword, string NewPassword)
        {
            int userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            var result = _svsUser.ChangePassword(userID, CurrentPassword, NewPassword, "C");

            return Json(result);
        }
        #endregion

        private byte[] ConvertFiletoBytes(IFormFile file)
        {
            byte[] p1 = null;
            if (file != null)
            {
                if (file.Length > 0)
                //Convert Image to byte and save to database
                {
                    using (var fs1 = file.OpenReadStream())
                    using (var ms1 = new System.IO.MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                }
            }
            return p1;
        }
    }
}