using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.Web.DTOS.Foto
{
    public class UploadFotoDto
    {
        [Required]
        public int BestemmingId { get; set; }

        [Required(ErrorMessage = "Selecteer een bestand.")]
        public IFormFile File { get; set; }
    }
}
