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
    public class StudentController : Controller
    {
        private readonly CoreContext coreContext;
        public StudentController()
        {
            this.coreContext = new CoreContext();
        }
        public ActionResult Index()
        {
            var models = coreContext.Users.Where(z => z.IsActive && !z.IsDelete && z.Role == RoleEnum.STUDENT)
                                    .Select(z => new UserModels
                                    {
                                        Id = z.Id,
                                        Code = z.Code,
                                        Name = z.Name,
                                        Email = z.Email,
                                        Phone = z.Phone,
                                        Address = z.Address,
                                        Gender = z.Gender,
                                    }).ToList();
            return View(models);
        }

        public ActionResult New()
        {
            var model = new UserModels();
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> New(UserModels model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Xác nhận mật khẩu không đúng");
            }
            
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var sinhVienEntities = new UsersEntities();
            sinhVienEntities.Code = model.Code;
            sinhVienEntities.Name = model.Name;
            sinhVienEntities.Email = model.Email;
            sinhVienEntities.Password = model.Password;
            sinhVienEntities.Phone = model.Phone;
            sinhVienEntities.Address = model.Address;
            sinhVienEntities.IsActive = model.IsActive;
            sinhVienEntities.CreatedAt = model.CreatedAt;
            sinhVienEntities.UpdatedAt = model.UpdatedAt;
            sinhVienEntities.Role = RoleEnum.STUDENT;
            coreContext.Users.Add(sinhVienEntities);
            var result = await coreContext.SaveChangesAsync();
            if (result >= 1)
            {
                TempData["Successful"] = "Thêm sinh viên thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IntervalServer"] = "Lỗi thêm mới sinh viên";
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

        public async Task<ActionResult> Destroy(int Id)
        {
            var entity = await coreContext.Users.FirstOrDefaultAsync(z => z.Id == Id);
            if (entity != null)
            {
                entity.IsDelete = true;
                entity.IsActive = false;
                entity.UpdatedAt = DateTime.Now;
                var Response = await coreContext.SaveChangesAsync();
                if (Response >= 1)
                {
                    TempData["Successful"] = "Xóa sinh viên thành công";
                }
                else
                {
                    TempData["IntervalServer"] = "Lỗi xóa sinh viên";
                }
            }
            return RedirectToAction("Index");
        }
    }
}