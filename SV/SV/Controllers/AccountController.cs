using Newtonsoft.Json;
using SV.Entities;
using SV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SV.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var _context = new CoreContext())
            {
                var User = _context.Users.Where(z => z.IsActive && z.Email == model.Email && z.Password == model.Password).FirstOrDefault();

                if (User != null)
                {
                    TempData["MessagesSuccessful"] = "Đăng nhập thành công.";
                    UserSession userSession = new UserSession();
                    userSession.FullName = User.Name;
                    userSession.Email = model.Email;
                    userSession.Role = User.Role;
                    userSession.Id = User.Id;
                    userSession.IsAuthenticated = true;
                    Session.Add("User", userSession);
                    string myObjectJson = JsonConvert.SerializeObject(userSession);
                    HttpCookie userCookie = new HttpCookie("UserCookie");
                    userCookie.Expires = DateTime.Now.AddDays(360);
                    userCookie.Value = Server.UrlEncode(myObjectJson);
                    HttpContext.Response.Cookies.Add(userCookie);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["MessagesError"] = "Thông tin đăng nhập không chính xác.";
                    return View(model);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}