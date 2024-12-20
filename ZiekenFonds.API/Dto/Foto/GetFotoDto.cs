using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Foto
{
    public class GetFotoDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "De naam mag maximaal 30 tekens lang zijn.")]
        public string Naam { get; set; }
        
        public string BestemmingNaam { get; set; }
    }
}
