using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessApp.Entity
{
    public class RequestResponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Response { get; set; }
        public EnumResponseType ResponseType { get; set; }
        public DateTime ResponseDate { get; set; }
        [ForeignKey("RequestId")]
        public Request Request { get; set; }
        public int RequestId { get; set; }
        public bool isPrivate { get; set; }

        public enum EnumResponseType
        {
            Sender = 1,
            Receiver = 2
        }
    }
}
