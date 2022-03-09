using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessApp.Entity
{
    public class UsersApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]
        public IdentityUser User { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string CompanyName { get; set; }
        public bool isDeleted { get; set; }
        public EnumApplicationStatus ApplicationStatus { get; set; }
        public enum EnumApplicationStatus
        {
            Waiting = 1,
            Accepted = 2
        }
    }
}
