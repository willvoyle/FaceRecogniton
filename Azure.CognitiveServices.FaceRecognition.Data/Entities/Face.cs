using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Azure.CognitiveServices.FaceRecognition.Data.Entities
{
    public class Face
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
