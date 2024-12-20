using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Models
{
    public class Kind
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "PersoonId is Verplicht!")]
        public string PersoonId { get; set; }

        [Required(ErrorMessage = "Naam is Verplicht!")]
        [StringLength(50, ErrorMessage = "Naam mag maximaal 50 karakters zijn!")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Voornaam is Verplicht!")]
        [StringLength(50, ErrorMessage = "Voornaam mag maximaal 50 karakters zijn!")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Geboortedatum is Verplicht!")]
        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }

        [StringLength(200, ErrorMessage = "Naam mag maximaal 200 karakters zijn!")]
        public string? Allergieën { get; set; }

        [StringLength(200, ErrorMessage = "Naam mag maximaal 200 karakters zijn!")]
        public string? Medicatie { get; set; }

        // Relaties
        public List<Deelnemer> Deelnemers { get; set; }

        public CustomUser Persoon { get; set; }
    }
}