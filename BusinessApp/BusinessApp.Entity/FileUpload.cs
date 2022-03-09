using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessApp.Entity
{
    public class FileUpload
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("RequestId")]
        public Request Request { get; set; }
        public int? RequestId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }

    }
}
