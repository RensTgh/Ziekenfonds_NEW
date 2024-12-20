using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Kind
{
    public class GetKind
    {
        [Required(ErrorMessage = "De naam is verplicht.")]
        [StringLength(50, ErrorMessage = "De naam mag maximaal 50 karakters zijn.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "De voornaam is verplicht.")]
        [StringLength(50, ErrorMessage = "De naam mag maximaal 50 karakters zijn.")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Einddatum is verplicht!")]
        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }

        public string? Allergieën { get; set; }
        public string? Medicatie { get; set; }

        // Extra velden voor persoon als ouder
        public string OuderNaam { get; set; }

        public string OuderVoornaam { get; set; }
    }
}