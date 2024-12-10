using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Models
{
    public class Bestemming
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code is verplicht!")]
        [StringLength(50, ErrorMessage = "Code mag maximaal 50 karakters zijn!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Naam is verplicht!")]
        [StringLength(75, ErrorMessage = "Naam mag maximaal 75 karakters zijn!")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Beschrijving is verplicht!")]
        [StringLength(200, ErrorMessage = "Naam mag maximaal 200 karakters zijn!")]
        public string Beschrijving { get; set; }

        [Required(ErrorMessage = "Mininum leeftijd is verplicht!")]
        public int MinLeeftijd { get; set; }

        [Required(ErrorMessage = "Maximum leeftijd is verplicht!")]
        public int MaxLeeftijd { get; set; }

        // Relaties
        public List<Groepsreis> Groepsreizen { get; set; }

        public List<Review> Reviews { get; set; }

        public List<Foto> Fotos { get; set; }
    }
}