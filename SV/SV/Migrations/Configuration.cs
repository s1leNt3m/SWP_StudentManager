namespace SV.Migrations
{
    using SV.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SV.Entities.CoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SV.Entities.CoreContext context)
        {
            context.Users.AddOrUpdate(z => z.Code, new UsersEntities
            {
                Email = "admin@gmail.com",
                Password = "123456",
                Name = "Admin",
                Code = "0001",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Gender = 1,
                IsActive = true,
                Role = SV.Enum.RoleEnum.ADMIN,
            });

            context.Users.AddOrUpdate(z => z.Code, new UsersEntities
            {
                Email = "giaovien2@gmail.com",
                Password = "123456",
                Name = "Giáo Viên A",
                Code = "0002",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Gender = 1,
                IsActive = true,
                Role = SV.Enum.RoleEnum.TEACHER,
            });

            context.Users.AddOrUpdate(z => z.Code, new UsersEntities
            {
                Email = "giaovien3@gmail.com",
                Password = "123456",
                Name = "Giáo Viên B",
                Code = "0003",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Gender = 1,
                IsActive = true,
                Role = SV.Enum.RoleEnum.TEACHER,
            });

            context.Users.AddOrUpdate(z => z.Code, new UsersEntities
            {
                Email = "giaovien4@gmail.com",
                Password = "123456",
                Name = "Giáo Viên C",
                Code = "0004",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Gender = 1,
                IsActive = true,
                Role = SV.Enum.RoleEnum.TEACHER,
            });

            context.Users.AddOrUpdate(z => z.Code, new UsersEntities
            {
                Email = "giaovien5@gmail.com",
                Password = "123456",
                Name = "Giáo Viên D",
                Code = "0005",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Gender = 1,
                IsActive = true,
                Role = SV.Enum.RoleEnum.TEACHER,
            });

            context.Lops.AddOrUpdate(z => z.Name, new LopEntities
            {
                Name = "Lớp Tin Học",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true
            });

            context.Lops.AddOrUpdate(z => z.Name, new LopEntities
            {
                Name = "Lớp Kế Toán",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true
            });

            context.Lops.AddOrUpdate(z => z.Name, new LopEntities
            {
                Name = "Lớp Kinh Doanh",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true
            });
        }
    }
}
