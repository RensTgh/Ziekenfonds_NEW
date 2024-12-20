using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Foto
{
    public class GetFotoDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "De bestandsnaam mag maximaal 100 tekens lang zijn.")]
        public string Naam { get; set; }

        public string BestemmingNaam { get; set; }
    }
}