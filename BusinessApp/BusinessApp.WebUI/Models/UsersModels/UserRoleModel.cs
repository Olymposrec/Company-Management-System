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
    public class UserRoleModel
    {
        public int Id { get; set; }
        public RoleType UserRoleType { get; set; }
        [Required(ErrorMessage ="Role Name is required.")]
        [Display(Prompt = "Role Name",Name ="Role Name")]
        public string RoleName { get; set; }

        public enum RoleType
        {
            Admin = 1,
            User = 2
        }
    }

    public class RoleDetails
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
    public class RoleEditModel
    {
        public string RoleId { get; set; }
        [Display(Prompt = "Role Name")]
        public string RoleName { get; set; }
        public string[] IdsToDelete { get; set; }
        public string[] IdsToAdd { get; set; }

    }
}
