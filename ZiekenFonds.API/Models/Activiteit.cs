using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Models
{
    public class Activiteit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naam is verplicht!")]
        [StringLength(50, ErrorMessage = "Naam mag maximaal 50 karakters zijn!")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Beschrijving is verplicht!")]
        [StringLength(200, ErrorMessage = "Naam mag maximaal 200 karakters zijn!")]
        public string Beschrijving { get; set; }

        // Relaties
        public List<Programma> Programmas { get; set; }
    }
}