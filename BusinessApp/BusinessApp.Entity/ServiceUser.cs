using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessApp.Entity
{
    public class ServiceUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("ServiceId")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }

    }
}
