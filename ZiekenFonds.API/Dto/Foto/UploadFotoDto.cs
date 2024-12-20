using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Foto
{
    public class UploadFotoDto
    {
            [Required]
            public IFormFile File { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "De naam mag maximaal 30 tekens lang zijn.")]
            public string Naam { get; set; }

            [Required]
            public int BestemmingId { get; set; } 

    }
}
