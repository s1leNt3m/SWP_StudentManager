using SV.Entities;
using SV.Enum;
using SV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SV.Controllers
{
    public class HomeController : Controller
    {
        private readonly CoreContext coreContext;
        public HomeController()
        {
            this.coreContext = new CoreContext();
        }
        public ActionResult Index()
        {
            List<UserPointModels> models = new List<UserPointModels>();
            ViewBag.SV = coreContext.Users.Where(w => w.Role == Enum.RoleEnum.STUDENT).Count();
            ViewBag.GV = coreContext.Users.Where(w => w.Role == Enum.RoleEnum.TEACHER).Count();
            ViewBag.ND = coreContext.Users.Where(w => w.Role == Enum.RoleEnum.ADMIN).Count();

            var user = (UserSession)Session["User"];
            if (user != null && user.Id > 0 && user.Role == Enum.RoleEnum.STUDENT)
            {
                models = coreContext.Users.Join(coreContext.UserPoints, u => u.Id, up => up.UserId, (u, up) => new { u = u, up = up })
                    .Where(z => z.u.Id == user.Id)
                                        .Select(z => new UserPointModels
                                        {
                                            Id = z.u.Id,
                                            Code = z.u.Code,
                                            Name = z.u.Name,
                                            Email = z.u.Email,
                                            PointStudy = z.up.PointStudy,
                                            PointGK = z.up.PointGK,
                                            PointCK = z.up.PointCK
                                        }).ToList();

                var schedule = coreContext.Users.Join(coreContext.Schedules, u => u.Id, s => s.StudentId, (u, s) => new { u = u, s = s })
                    .Where(z => z.u.Id == user.Id)
                                        .Select(z => new UserScheduleModels
                                        {
                                            UserId = z.u.Id,
                                            Code = z.u.Code,
                                            Name = z.u.Name,
                                            Email = z.u.Email,
                                            Rank = z.s.Rank,
                                            Session = z.s.Session,
                                            LopId = z.s.LopId,
                                            LopName = coreContext.Lops.FirstOrDefault(f=>f.Id == z.s.LopId).Name
                                        }).ToList();
                ViewData["Schedule"] = schedule;
            }
            return View(models);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}