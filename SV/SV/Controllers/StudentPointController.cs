using SV.Entities;
using SV.Enum;
using SV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SV.Controllers
{
    public class StudentPointController : Controller
    {
        private readonly CoreContext coreContext;
        public StudentPointController()
        {
            this.coreContext = new CoreContext();
        }
        public ActionResult Index()
        {
            var models = coreContext.Users.Join(coreContext.UserPoints, u => u.Id, up => up.UserId, (u, up) => new { u = u, up = up })
                .Where(z => z.u.IsActive && !z.u.IsDelete && z.u.Role == RoleEnum.STUDENT
                    && z.up.Year == DateTime.Now.Year && z.up.Period == PeriodEnum.KY1)
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
            List<SelectListItem> lstHK = new List<SelectListItem>()
            {
               new SelectListItem(){ Text = "Học Kỳ I", Value = "I"},
               new SelectListItem(){ Text = "Học Kỳ II", Value = "II"}
            };
            ViewBag.HocKy = lstHK;
            List<SelectListItem> lstNam = new List<SelectListItem>()
            {
               new SelectListItem(){ Text = "2022", Value = "2022"},
               new SelectListItem(){ Text = "2021", Value = "2021"},
               new SelectListItem(){ Text = "2020", Value = "2020"},
               new SelectListItem(){ Text = "2019", Value = "2019"},
               new SelectListItem(){ Text = "2018", Value = "2018"},
               new SelectListItem(){ Text = "2017", Value = "2017"},
               new SelectListItem(){ Text = "2016", Value = "2016"},
               new SelectListItem(){ Text = "2015", Value = "2015"},
               new SelectListItem(){ Text = "2014", Value = "2014"},
               new SelectListItem(){ Text = "2013", Value = "2013"},
               new SelectListItem(){ Text = "2012", Value = "2012"},
               new SelectListItem(){ Text = "2011", Value = "2011"},
            };
            ViewBag.NamHoc = lstNam;
            return View(models);
        }

        [HttpPost]
        public ActionResult Search(int nam, string hk)
        {
            var _userPoints = coreContext.UserPoints.AsQueryable();
            if (nam > 0)
            {
                _userPoints = _userPoints.Where(w => w.Year == nam);
            }
            if (!string.IsNullOrWhiteSpace(hk))
            {
                if (hk == "I")
                {
                    _userPoints = _userPoints.Where(w => w.Period == PeriodEnum.KY1);
                }
                else
                {
                    _userPoints = _userPoints.Where(w => w.Period == PeriodEnum.KY2);
                }
            }
            var models = coreContext.Users.Join(coreContext.UserPoints, u => u.Id, up => up.UserId, (u, up) => new { u = u, up = up })
                .Where(z => z.u.IsActive && !z.u.IsDelete && z.u.Role == RoleEnum.STUDENT
                    && z.up.Year == DateTime.Now.Year && z.up.Period == PeriodEnum.KY1)
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
            List<SelectListItem> lstHK = new List<SelectListItem>()
            {
               new SelectListItem(){ Text = "Học Kỳ I", Value = "I"},
               new SelectListItem(){ Text = "Học Kỳ II", Value = "II"}
            };
            ViewBag.HocKy = lstHK;
            List<SelectListItem> lstNam = new List<SelectListItem>()
            {
               new SelectListItem(){ Text = "2022", Value = "2022"},
               new SelectListItem(){ Text = "2021", Value = "2021"},
               new SelectListItem(){ Text = "2020", Value = "2020"},
               new SelectListItem(){ Text = "2019", Value = "2019"},
               new SelectListItem(){ Text = "2018", Value = "2018"},
               new SelectListItem(){ Text = "2017", Value = "2017"},
               new SelectListItem(){ Text = "2016", Value = "2016"},
               new SelectListItem(){ Text = "2015", Value = "2015"},
               new SelectListItem(){ Text = "2014", Value = "2014"},
               new SelectListItem(){ Text = "2013", Value = "2013"},
               new SelectListItem(){ Text = "2012", Value = "2012"},
               new SelectListItem(){ Text = "2011", Value = "2011"},
            };
            ViewBag.NamHoc = lstNam;
            return View(models);
        }

        public ActionResult New()
        {
            var _sVs = coreContext.Users.Where(z => z.IsActive && !z.IsDelete && z.Role == Enum.RoleEnum.STUDENT).OrderBy(z => z.Name).ToList();
            ViewBag.SinhViens = _sVs;
            List<SelectListItem> lstHK = new List<SelectListItem>()
            {
               new SelectListItem(){ Text = "Học Kỳ I", Value = "I"},
               new SelectListItem(){ Text = "Học Kỳ II", Value = "II"}
            };
            ViewBag.HocKy = lstHK;
            List<SelectListItem> lstNam = new List<SelectListItem>()
            {
               new SelectListItem(){ Text = "2022", Value = "2022"},
               new SelectListItem(){ Text = "2021", Value = "2021"},
               new SelectListItem(){ Text = "2020", Value = "2020"},
               new SelectListItem(){ Text = "2019", Value = "2019"},
               new SelectListItem(){ Text = "2018", Value = "2018"},
               new SelectListItem(){ Text = "2017", Value = "2017"},
               new SelectListItem(){ Text = "2016", Value = "2016"},
               new SelectListItem(){ Text = "2015", Value = "2015"},
               new SelectListItem(){ Text = "2014", Value = "2014"},
               new SelectListItem(){ Text = "2013", Value = "2013"},
               new SelectListItem(){ Text = "2012", Value = "2012"},
               new SelectListItem(){ Text = "2011", Value = "2011"},
            };
            ViewBag.NamHoc = lstNam;
            var model = new UserPointModels();
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> New(UserPointModels model)
        {
            var pointEntities = new UserPointEntities();

            pointEntities.UserId = model.SinhVienId;
            pointEntities.Year = model.Year;
            pointEntities.Period = model.Periods == "I" ? PeriodEnum.KY1 : PeriodEnum.KY2;
            pointEntities.PointStudy = model.PointStudy;
            pointEntities.PointGK = model.PointGK;
            pointEntities.PointCK = model.PointCK;
            pointEntities.IsActive = model.IsActive;
            pointEntities.CreatedAt = model.CreatedAt;
            pointEntities.UpdatedAt = model.UpdatedAt;
            coreContext.UserPoints.Add(pointEntities);
            var result = await coreContext.SaveChangesAsync();
            if (result >= 1)
            {
                TempData["Successful"] = "Thêm điểm sinh viên thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IntervalServer"] = "Lỗi thêm điểm sinh viên";
            }
            return View(model);
        }


        public async Task<ActionResult> Edit(int Id)
        {
            var model = await coreContext.Users.Where(z => z.Id == Id && z.IsActive)
                                                .Select(z => new UserModels
                                                {
                                                    Name = z.Name,
                                                    IsActive = z.IsActive,
                                                    Id = z.Id
                                                }).FirstOrDefaultAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserModels model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Xác nhận mật khẩu không đúng");
            }
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var sinhVienEntities = coreContext.Users.FirstOrDefault(z => z.Id == model.Id);
            sinhVienEntities.Code = model.Code;
            sinhVienEntities.Name = model.Name;
            sinhVienEntities.Email = model.Email;
            sinhVienEntities.Password = model.Password;
            sinhVienEntities.Phone = model.Phone;
            sinhVienEntities.Address = model.Address;
            sinhVienEntities.IsActive = model.IsActive;
            sinhVienEntities.UpdatedAt = model.UpdatedAt;
            var Response = await coreContext.SaveChangesAsync();
            if (Response >= 0)
            {
                TempData["Successful"] = "Cập nhật sinh viên học thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IntervalServer"] = "Lỗi chỉnh sửa sinh viên";
            }
            return View(model);
        }
    }
}