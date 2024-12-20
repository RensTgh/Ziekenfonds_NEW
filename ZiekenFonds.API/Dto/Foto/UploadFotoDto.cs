using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Foto
{
    public class UploadFotoDto
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public int BestemmingId { get; set; }
    }
}