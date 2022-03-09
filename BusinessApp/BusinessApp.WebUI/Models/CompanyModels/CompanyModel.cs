using BusinessApp.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessApp.WebUI.Models.CompanyModels
{
    public class CompanyModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Company Name is Required.")]
        [DataType(DataType.Text,ErrorMessage = "Company Name must be text.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Company must be Between 3-100.")]
        [Display(Prompt ="Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tax Number is Required.")]
        [DataType(DataType.Text)]
        [StringLength(11,MinimumLength =11,ErrorMessage ="Tax number must be equal to 11.")]
        [Display(Prompt = "Tax Number", Name = "Tax Number")]
        public string TaxNumber { get; set; }
        [Required(ErrorMessage = "Phone Number is Required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone Number must be equal to 11.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Prompt = "Phone Number", Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is Required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Email must be Between 3-100.")]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Email")]
        public string Email { get; set; }

        public List<Identity.User> Users { get; set; }
        public List<Company> Companies { get; set; }

    }
}
