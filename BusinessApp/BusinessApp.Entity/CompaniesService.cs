using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessApp.Entity
{
    public class CompaniesService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        [NotMapped]
        public Request Requests { get; set; }
      


    }
}
