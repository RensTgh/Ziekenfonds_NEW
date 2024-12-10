using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Kind
{
    public class UpdateKind
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "De naam is verplicht!")]
        [StringLength(50, ErrorMessage = "Beschrijving mag maximaal 50 karakters lang zijn!")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "De voornaam is verplicht.")]
        [StringLength(50, ErrorMessage = "De naam mag maximaal 50 karakters zijn.")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Einddatum is verplicht!")]
        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }
        public string? Allergieën { get; set; }
        public string? Medicatie { get; set; }
    }
}
