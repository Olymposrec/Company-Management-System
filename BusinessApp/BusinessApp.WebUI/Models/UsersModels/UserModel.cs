using BusinessApp.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.Models.UsersModels
{
    public class UserModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="First Name is required.")]
        [DataType(DataType.Text)]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "First Name Length must be between 3-60.")]
        [Display(Prompt = "First Name", Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Last Name Length must be between 3-60.")]
        [DataType(DataType.Text)]
        [Display(Prompt = "Last Name",Name ="Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Text)]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "User Name Length must be between 3-60.")]
        [Display(Prompt = "User Name",Name ="User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Email must be Between 3-100.")]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone Number Length must be equeal to 11.")]
        [Display(Prompt = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }  
        public List<IdentityRole> Roles { get; set; }
        public List<Entity.Company> Companies { get; set; }
        [Required]
        public string SelectedRole { get; set; }
        public string UserRole { get; set; }
        public int SelectedCompany { get; set; }
    }
}
