using BusinessApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.DataAccess.Concrete.EfCore
{
    public class BusinessAppContext : DbContext
    {
        public BusinessAppContext(DbContextOptions<BusinessAppContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompaniesService> CompaniesService { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UsersApplication> UsersApplications { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }
        public DbSet<RequestResponse> RequestResponses { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<EmployeeRequests> EmployeeRequests { get; set; }
        public DbSet<RequestDepartment> RequestDepartments { get; set; }
        public DbSet<Log> Logs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersApplication>().HasKey(c => new { c.Id,c.UserId});
            modelBuilder.Entity<RequestDepartment>().HasKey(c => new { c.Id });
            modelBuilder.Entity<EmployeeDepartment>().HasKey(c => new { c.Id, c.EmployeeId, c.DepartmentId });
            modelBuilder.Entity<EmployeeRequests>().HasKey(c => new { c.Id });

            modelBuilder.Entity<Request>().HasKey(c => new { c.Id});
            modelBuilder.Entity<Department>().HasKey(c => new { c.Id});

            modelBuilder.Entity<CompaniesService>().HasKey(c => new { c.Id, c.CompanyId, c.ServiceId });
            modelBuilder.Entity<CompaniesService>().HasOne(fs => fs.Company).WithMany(f => f.CompaniesServices).HasForeignKey(f => f.CompanyId);
            modelBuilder.Entity<CompaniesService>().HasOne(fs => fs.Service).WithMany(f => f.CompaniesService).HasForeignKey(f => f.ServiceId);


        }
    }
}
