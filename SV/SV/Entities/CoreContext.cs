using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SV.Entities
{
    public class CoreContext : DbContext
    {
        public CoreContext() : base("name=Core_Context")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                            .Where(type => !String.IsNullOrEmpty(type.Namespace))
                                            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                                            type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            Database.SetInitializer<CoreContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UsersEntities> Users { get; set; }
        public DbSet<LopEntities> Lops { get; set; }
        public DbSet<UserLopEntities> UserLops { get; set; }
        public DbSet<SubjectLopEntities> SubjectLops { get; set; }
        public DbSet<SubjectEntities> Subjects { get; set; }
        public DbSet<LopScheduleEntities> LopSchedules { get; set; }
        public DbSet<ScheduleEntities> Schedules { get; set; }

    }
}