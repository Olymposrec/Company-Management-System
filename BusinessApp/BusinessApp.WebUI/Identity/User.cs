using BusinessApp.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApp.WebUI.Identity
{
    public class User:IdentityUser
    {
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        [ForeignKey("CompanyId")]
        public int? CompanyId { get; set; }
        public bool isPassive { get; set; }
    }
}
