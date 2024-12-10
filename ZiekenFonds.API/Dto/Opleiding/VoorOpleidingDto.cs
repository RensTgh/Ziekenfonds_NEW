using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Opleiding
{
    public class VoorOpleidingDto
    {
        [Required(ErrorMessage = "De naam is verplicht.")]
        [StringLength(50, ErrorMessage = "De naam mag maximaal 50 karakters zijn.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Beschrijving is verplicht!")]
        [StringLength(100, ErrorMessage = "Beschrijving mag maximaal 100 karakters lang zijn!")]
        public string Beschrijving { get; set; }

        [Required(ErrorMessage = "Begindatum is verplicht!")]
        [DataType(DataType.Date)]
        public DateTime Begindatum { get; set; }

        [Required(ErrorMessage = "Einddatum is verplicht!")]
        [DataType(DataType.Date)]
        public DateTime Einddatum { get; set; }

        [Required(ErrorMessage = "Aantalplaatsen is verplicht!")]
        public int AantalPlaatsen { get; set; }
    }
}