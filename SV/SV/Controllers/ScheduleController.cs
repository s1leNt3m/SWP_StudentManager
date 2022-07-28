using SV.Entities;
using SV.Enum;
using SV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SV.Controllers
{
    public class ScheduleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DsLop(RankEnum rank, SessionEnum sessionType)
        {
            var DbContext = new CoreContext();
            var LopIds = DbContext.LopSchedules.Where(m => m.Rank == rank && m.Session == sessionType).Select(m => m.LopId);
            var Lops = DbContext.Lops.Where(m => LopIds.Contains(m.Id))
                                    .Select(m => new ClassModels
                                    {
                                        Id = m.Id,
                                        Name = m.Name,
                                        Rank = rank,
                                        Session = sessionType
                                    }).ToList();
            return View(Lops);
        }

        public ActionResult DsStudent(int lopId, RankEnum rank, SessionEnum sessionType)
        {
            var DbContext = new CoreContext();
            var StudentIds = DbContext.UserLops.Where(m => m.LopId == lopId).Select(m => m.UserId);
            var Students = DbContext.Users.Where(m => StudentIds.Contains(m.Id) && m.Role == RoleEnum.STUDENT)
                .Select(m => new StudentModels
                {
                    Id = m.Id,
                    Name = m.Name,
                    Email = m.Email,
                    Address = m.Address,
                    Rank = rank,
                    Session = sessionType,
                    LopId = lopId
                }).ToList();
            return View(Students);
        }

        [HttpPost]
        public JsonResult DiemDanh(ScheduleModels model)
        {
            var DbContext = new CoreContext();
            if (model.IsDiemDanh == false)
            {
                var Schedule = DbContext.Schedules.Where(m => m.LopId == model.LopId && 
                            m.StudentId == model.StudentId && m.Rank == model.Rank && m.Session == model.Session
                            && DbFunctions.TruncateTime(DateTime.Now) == DbFunctions.TruncateTime(m.CreatedAt)).FirstOrDefault();
                DbContext.Schedules.Remove(Schedule);
            }
            else
            {
                DbContext.Schedules.Add(new ScheduleEntities
                {
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                    LopId = model.LopId,
                    Rank = model.Rank,
                    Session = model.Session,
                    StudentId = model.StudentId,
                    UpdatedAt = DateTime.Now
                });
            }
            var Result = DbContext.SaveChanges() > 0;
            return Json(new { Status = 200, Success = Result });
        }
    }
}