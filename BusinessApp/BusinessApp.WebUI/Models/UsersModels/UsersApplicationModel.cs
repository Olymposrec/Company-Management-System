using BusinessApp.Entity;
using BusinessApp.WebUI.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.Models.UsersModels
{
    public class UsersApplicationModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Prompt = "First Name",Name ="First Name")]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "First Name between 3-30.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last Name between 3-30.")]
        [DataType(DataType.Text)]
        [Display(Prompt = "Last Name", Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "User Name between 3-60.")]
        [Display(Prompt = "User Name", Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Email must be Between 3-100.")]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Email", Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Prompt = "Phone Number", Name = "Phone Number")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone Number Length must be equeal to 11.")]
        [DataType(DataType.CreditCard)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Company Name is Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Company Name between 3-30.")]
        [Display(Prompt = "Company Name", Name = "Company Name")]
        [DataType(DataType.Text)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Prompt = "Password", Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "RePassword is required")]
        [DataType(DataType.Password)]
        [Display(Prompt = "RePassword", Name = "RePassword")]
        [Compare(nameof(Password), ErrorMessage = "Passwords Not Matched.")]
        public string RePassword { get; set; }

        public List<Company> Companies { get; set; }
        public List<User> Users { get; set; }
    }
    public class UsersApplicationListModel
    {
        public List<User> Users{ get; set; }
        public List<Entity.Company> Companies{ get; set; }
        public List<UsersApplication> UsersApplications{ get; set; }
    }
}
