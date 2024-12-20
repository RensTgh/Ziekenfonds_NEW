using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.Web.DTOS.Opleiding
{
    public class CreateOpleidingPageDto
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

        public List<int>? VereisteOpleidingIds { get; set; }

        public List<OpleidingPersoonPageDto> OpleidingenPersonen { get; set; }

        // Nodig om een select te tonen waar de gebruiker uit opleidingen kan kiezen, om deze toe te voegen als vereisteOpleidingen
        public List<OpleidingDto>? AllOpleidingen { get; set; } = new List<OpleidingDto>();
    }
}