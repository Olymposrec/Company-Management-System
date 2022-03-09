using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessApp.Entity
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isDefault { get; set; }
        public bool isDeleted { get; set; }
        public List<EmployeeDepartment> EmployeeDepartments { get; set; }
        public List<RequestDepartment> RequestDepartments { get; set; }


    }
}
