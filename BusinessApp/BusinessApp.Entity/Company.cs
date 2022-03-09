using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessApp.Entity
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool isDeleted { get; set; }

        // MANY TO MANY BIRLESEN TABLODAN GELEN DEGER
        public List<CompaniesService> CompaniesServices { get; set; }
    }
}
