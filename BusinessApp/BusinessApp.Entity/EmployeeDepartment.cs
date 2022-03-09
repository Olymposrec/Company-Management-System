using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessApp.Entity
{
    public class EmployeeDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("EmployeeId")]
        public string EmployeeId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
