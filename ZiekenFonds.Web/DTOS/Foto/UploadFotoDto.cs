using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.MVC.Dtos
{
    public class UploadFotoDto
    {
        [Required]
        public int BestemmingId { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}
