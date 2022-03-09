using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessApp.Entity
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public int  DepartmentId{ get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public bool isDeleted { get; set; }
        public EnumRequestStatus RequestStatus { get; set; }
        [ForeignKey("CompaniesServiceId")]
        public List<CompaniesService> CompaniesService { get; set; }
        public int CompaniesServiceId { get; set; }

        public List<RequestDepartment> RequestDepartment { get; set; }
        public enum EnumRequestStatus
        {
            Waiting = 1,
            Accepted = 2,
            Closed = 3
        }

    }
}
