using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessApp.Entity
{
    public class EmployeeRequests
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("EmployeeId")]
        public string EmployeeId { get; set; }
        public DateTime AddedDate { get; set; }
        public bool isDeleted { get; set; }

        [ForeignKey("RequestId")]
        public Request Request { get; set; }
        public int RequestId { get; set; }
     

    }
}
