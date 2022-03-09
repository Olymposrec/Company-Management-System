using BusinessApp.Entity;
using BusinessApp.WebUI.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.Models.UsersModels
{
    public class UserDetailsModel
    {
        
        public string UserId { get; set; }
        [Display(Prompt = "User Name",Name ="User Name")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "User Name Length must be between 3-60.")]
        [Required]
        public string UserName { get; set; }
        [Display(Prompt = "First Name",Name ="First Name")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "First Name Length must be between 3-60.")]
        [Required]
        public string FirstName { get; set; }
        [Display(Prompt = "Last Name", Name ="Last Name")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Last Name Length must be between 3-60.")]
        [Required]
        public string LastName { get; set; }
        [Display(Prompt = "Phone Number",Name ="Phone Number")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone Number Length must be equeal to 11.")]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Prompt = "Email")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Email must be Between 3-100.")]
        [Required]
        public string Email { get; set; }
        [Display(Prompt = "Email Confirmed")]
        [Required]
        public bool EmailConfirmed { get; set; }
        [Display(Prompt = "Selected Roles")]
        public string Role { get; set; }
        public int? CompanyId { get; set; }
    
        public List<IdentityRole> Roles { get; set; }
        public List<Company> Companies { get; set; }


    }
}
