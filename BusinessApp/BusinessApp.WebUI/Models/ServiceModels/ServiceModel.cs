using BusinessApp.Entity;
using BusinessApp.WebUI.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.Models.ServiceModels
{
    public class ServiceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Service Name is Required.")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Service Name Length must be between 3-50.")]
        [Display(Prompt ="Service Name", Name = "Service Name")]
        [DataType(DataType.Text, ErrorMessage = "Service Name must be text.")]
        public string ServiceName { get; set; }
        [Required(ErrorMessage = "Service Description is Required.")]
        [Display(Prompt = "Service Description", Name = "Service Description")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Service Description Length must be between 3-250.")]
        [DataType(DataType.Text, ErrorMessage = "Service Description must be text.")]
        public string ServiceDescription { get; set; }
        public int? DepartmentId { get; set; }
        public List<Department> Departments { get; set; }
        public List<Service> Services { get; set; }
    }
}
