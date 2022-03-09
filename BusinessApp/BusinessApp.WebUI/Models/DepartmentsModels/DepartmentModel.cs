using BusinessApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.Models.DepartmentsModels
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Department Name is Required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Department Name Length must be between 3-50.")]
        [Display(Prompt = "Department Name", Name = "Department Name")]
        [DataType(DataType.Text, ErrorMessage = "Department Name must be text.")]
        public string Name { get; set; }

        public List<Department> Departments { get; set; }
        public int? companyId { get; set; }
    }
}
