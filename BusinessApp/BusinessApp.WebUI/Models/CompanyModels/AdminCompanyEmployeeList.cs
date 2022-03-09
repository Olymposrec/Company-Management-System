using BusinessApp.Entity;
using BusinessApp.WebUI.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.Models.CompanyModels
{
    public class AdminCompanyEmployeeList
    {
        public List<Company> Companies { get; set; }
        public List<Department> Departments { get; set; }
        public List<Service> Services { get; set; }
        public List<EmployeeDepartment> EmployeeDepartments { get; set; }
        public int departmentId { get; set; }
        public List<User> Users { get; set; }
        public User User { get; set; }
    }
}
