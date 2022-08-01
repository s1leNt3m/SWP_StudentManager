using Newtonsoft.Json;
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
    public class ClassController : Controller
    {
        private readonly CoreContext coreContext;
        public ClassController()
        {
            this.coreContext = new CoreContext();
        }
        public ActionResult Index()
        {
            var models = coreContext.Lops.Where(z => z.IsActive && !z.IsDelete)
                                    .Select(z => new ClassModels
                                    {
                                        Id = z.Id,
                                        Code = z.Code,
                                        Name = z.Name,
                                    }).ToList();
            return View(models);
        }

        public ActionResult New()
        {
            var model = new ClassModels();
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> New(ClassModels model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var lopEntities = new LopEntities();
            lopEntities.Code = model.Code;
            lopEntities.Name = model.Name;
            lopEntities.IsActive = model.IsActive;
            lopEntities.CreatedAt = model.CreatedAt;
            lopEntities.UpdatedAt = model.UpdatedAt;
            coreContext.Lops.Add(lopEntities);
            var result = await coreContext.SaveChangesAsync();
            if (result >= 1)
            {
                TempData["Successful"] = "Thêm mới lớp học thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IntervalServer"] = "Lỗi thêm mới lớp học";
            }
            return View(model);
        }


        public async Task<ActionResult> Edit(int Id)
        {
            var model = await coreContext.Lops.Where(z => z.Id == Id && z.IsActive)
                                                .Select(z => new ClassModels
                                                {
                                                    Code = z.Code,
                                                    Name = z.Name,
                                                    IsActive = z.IsActive,
                                                    SubjectId = z.SubjectId,
                                                    Id = z.Id
                                                }).FirstOrDefaultAsync();
            model.SinhVienIds = coreContext.UserLops.Where(w => w.LopId == Id).Select(s => s.UserId).ToList();
            var _sVs = coreContext.Users.Where(z => z.IsActive && !z.IsDelete && z.Role == Enum.RoleEnum.STUDENT).OrderBy(z => z.Name).ToList();
            ViewBag.SinhViens = _sVs;
            var _sBs = coreContext.Subjects.Where(z => z.IsActive && !z.IsDelete).ToList();
            ViewBag.Subjects = _sBs;
            var listSchedules = coreContext.LopSchedules.Where(w => w.LopId == Id).ToList();
            if (listSchedules.Any(w=>w.Rank == RankEnum.THU2))
            {
                model.TimeLines.Thu2 = true;
                if (listSchedules.Any(w => w.Session == SessionEnum.SANG))
                {
                    model.TimeLines.CheckBoxSangT2 = true;
                }
                if (listSchedules.Any(w => w.Session == SessionEnum.CHIEU))
                {
                    model.TimeLines.CheckBoxChieuT2 = true;
                }
            }
            if (listSchedules.Any(w => w.Rank == RankEnum.THU3))
            {
                model.TimeLines.Thu3 = true;
                if (listSchedules.Any(w => w.Session == SessionEnum.SANG))
                {
                    model.TimeLines.CheckBoxSangT3 = true;
                }
                if (listSchedules.Any(w => w.Session == SessionEnum.CHIEU))
                {
                    model.TimeLines.CheckBoxChieuT3 = true;
                }
            }
            if (listSchedules.Any(w => w.Rank == RankEnum.THU4))
            {
                model.TimeLines.Thu4 = true;
                if (listSchedules.Any(w => w.Session == SessionEnum.SANG))
                {
                    model.TimeLines.CheckBoxSangT4 = true;
                }
                if (listSchedules.Any(w => w.Session == SessionEnum.CHIEU))
                {
                    model.TimeLines.CheckBoxChieuT4 = true;
                }
            }
            if (listSchedules.Any(w => w.Rank == RankEnum.THU5))
            {
                model.TimeLines.Thu5 = true;
                if (listSchedules.Any(w => w.Session == SessionEnum.SANG))
                {
                    model.TimeLines.CheckBoxSangT5 = true;
                }
                if (listSchedules.Any(w => w.Session == SessionEnum.CHIEU))
                {
                    model.TimeLines.CheckBoxChieuT5 = true;
                }
            }
            if (listSchedules.Any(w => w.Rank == RankEnum.THU6))
            {
                model.TimeLines.Thu6 = true;
                if (listSchedules.Any(w => w.Session == SessionEnum.SANG))
                {
                    model.TimeLines.CheckBoxSangT6 = true;
                }
                if (listSchedules.Any(w => w.Session == SessionEnum.CHIEU))
                {
                    model.TimeLines.CheckBoxChieuT6 = true;
                }
            }
            if (listSchedules.Any(w => w.Rank == RankEnum.THU7))
            {
                model.TimeLines.Thu7 = true;
                if (listSchedules.Any(w => w.Session == SessionEnum.SANG))
                {
                    model.TimeLines.CheckBoxSangT7 = true;
                }
                if (listSchedules.Any(w => w.Session == SessionEnum.CHIEU))
                {
                    model.TimeLines.CheckBoxChieuT7 = true;
                }
            }
            if (listSchedules.Any(w => w.Rank == RankEnum.CN))
            {
                model.TimeLines.Thu0 = true;
                if (listSchedules.Any(w => w.Session == SessionEnum.SANG))
                {
                    model.TimeLines.CheckBoxSangT0 = true;
                }
                if (listSchedules.Any(w => w.Session == SessionEnum.CHIEU))
                {
                    model.TimeLines.CheckBoxChieuT0 = true;
                }
            }
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> Edit(ClassModels model)
        {
            if (ModelState.IsValid == false)
            {
                model.SinhVienIds = coreContext.UserLops.Where(w => w.LopId == model.Id).Select(s => s.UserId).ToList();
                var _sVs = coreContext.Users.Where(z => z.IsActive && !z.IsDelete && z.Role == Enum.RoleEnum.STUDENT).OrderBy(z => z.Name)
                                           .Select(z => new SelectListItem
                                           {
                                               Value = z.Id.ToString(),
                                               Text = z.Name
                                           }).ToList();
                if (_sVs != null && _sVs.Any())
                {
                    model.SinhViens = _sVs;
                }
                var _sBs = coreContext.Subjects.Where(z => z.IsActive && !z.IsDelete)
                                            .Select(z => new SelectListItem
                                            {
                                                Value = z.Id.ToString(),
                                                Text = z.Name
                                            }).ToList();
                if (_sBs != null && _sBs.Any())
                {
                    model.Subjects = _sBs;
                }
                return View(model);
            }
            var lopEntities = coreContext.Lops.FirstOrDefault(z => z.Id == model.Id);
            lopEntities.Code = model.Code;
            lopEntities.Name = model.Name;
            lopEntities.SubjectId = model.SubjectId;
            lopEntities.IsActive = model.IsActive;
            lopEntities.UpdatedAt = model.UpdatedAt;
            var trans = coreContext.Database.BeginTransaction();
            try
            {
                var Response = await coreContext.SaveChangesAsync();
                if (Response >= 0)
                {
                    //lấy thông tin thời khóa biểu
                    var deleteSchedule = coreContext.LopSchedules.Where(w => w.LopId == lopEntities.Id);
                    coreContext.LopSchedules.RemoveRange(deleteSchedule);
                    await coreContext.SaveChangesAsync();
                    List<LopScheduleEntities> lopScheduleEntities = new List<LopScheduleEntities>();
                    if (model.TimeLines.Thu2)
                    {
                        if (model.TimeLines.CheckBoxSangT2)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities() { 
                                LopId = lopEntities.Id,
                                Rank = RankEnum.THU2,
                                Session = SessionEnum.SANG,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                        if (model.TimeLines.CheckBoxChieuT2)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.THU2,
                                Session = SessionEnum.CHIEU,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                    }
                    if (model.TimeLines.Thu3)
                    {
                        if (model.TimeLines.CheckBoxSangT3)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.THU3,
                                Session = SessionEnum.SANG,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                        if (model.TimeLines.CheckBoxChieuT3)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.THU3,
                                Session = SessionEnum.CHIEU,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                    }
                    if (model.TimeLines.Thu4)
                    {
                        if (model.TimeLines.CheckBoxSangT4)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.THU4,
                                Session = SessionEnum.SANG,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                        if (model.TimeLines.CheckBoxChieuT4)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.THU4,
                                Session = SessionEnum.CHIEU,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                    }
                    if (model.TimeLines.Thu5)
                    {
                        if (model.TimeLines.CheckBoxSangT5)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.THU5,
                                Session = SessionEnum.SANG,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                        if (model.TimeLines.CheckBoxChieuT5)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.THU5,
                                Session = SessionEnum.CHIEU,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                    }
                    if (model.TimeLines.Thu6)
                    {
                        if (model.TimeLines.CheckBoxSangT6)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.THU6,
                                Session = SessionEnum.SANG,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                        if (model.TimeLines.CheckBoxChieuT6)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.THU6,
                                Session = SessionEnum.CHIEU,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                    }
                    if (model.TimeLines.Thu7)
                    {
                        if (model.TimeLines.CheckBoxSangT7)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.THU7,
                                Session = SessionEnum.SANG,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                        if (model.TimeLines.CheckBoxChieuT7)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.THU7,
                                Session = SessionEnum.CHIEU,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                    }
                    if (model.TimeLines.Thu0)
                    {
                        if (model.TimeLines.CheckBoxSangT0)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.CN,
                                Session = SessionEnum.SANG,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                        if (model.TimeLines.CheckBoxChieuT0)
                        {
                            lopScheduleEntities.Add(new LopScheduleEntities()
                            {
                                LopId = lopEntities.Id,
                                Rank = RankEnum.CN,
                                Session = SessionEnum.CHIEU,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });
                        }
                    }
                    coreContext.LopSchedules.AddRange(lopScheduleEntities);

                    //Lưu thông tin sinh viên của lớp học
                    var delete = coreContext.UserLops.Where(w => w.LopId == lopEntities.Id);
                    coreContext.UserLops.RemoveRange(delete);
                    await coreContext.SaveChangesAsync();
                    if (model.SinhVienIds != null && model.SinhVienIds.Any())
                    {
                        var sinhVienLop = new List<UserLopEntities>();
                        foreach (var item in model.SinhVienIds)
                        {
                            sinhVienLop.Add(new UserLopEntities()
                            {
                                UserId = item,
                                LopId = lopEntities.Id,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now
                            });                  
                        }
                        coreContext.UserLops.AddRange(sinhVienLop);
                    }
                    Response = await coreContext.SaveChangesAsync();
                    trans.Commit();
                }
                TempData["Successful"] = "Sửa thông tin lớp học thành công";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                model.SinhVienIds = coreContext.UserLops.Where(w => w.LopId == model.Id).Select(s => s.UserId).ToList();
                var _sVs = coreContext.Users.Where(z => z.IsActive && !z.IsDelete && z.Role == Enum.RoleEnum.STUDENT).OrderBy(z => z.Name)
                                           .Select(z => new SelectListItem
                                           {
                                               Value = z.Id.ToString(),
                                               Text = z.Name
                                           }).ToList();
                if (_sVs != null && _sVs.Any())
                {
                    model.SinhViens = _sVs;
                }
                var _sBs = coreContext.Subjects.Where(z => z.IsActive && !z.IsDelete)
                                            .Select(z => new SelectListItem
                                            {
                                                Value = z.Id.ToString(),
                                                Text = z.Name
                                            }).ToList();
                if (_sBs != null && _sBs.Any())
                {
                    model.Subjects = _sBs;
                }
                TempData["IntervalServer"] = "Lỗi sửa thông tin lớp học";
                trans.Rollback();
                return View(model);
            }
        }

        public async Task<ActionResult> Destroy(int Id)
        {
            var entity = await coreContext.Lops.FirstOrDefaultAsync(z => z.Id == Id);
            if (entity != null)
            {
                entity.IsDelete = true;
                entity.IsActive = false;
                entity.UpdatedAt = DateTime.Now;
                var Response = await coreContext.SaveChangesAsync();
                if (Response >= 1)
                {
                    TempData["Successful"] = "Xóa lớp học thành công";
                }
                else
                {
                    TempData["IntervalServer"] = "Lỗi xóa lớp học";
                }
            }
            return RedirectToAction("Index");
        }
    }
}