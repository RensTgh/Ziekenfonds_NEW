using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.Web.Models
{
    public class Bestemming
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Naam is verplicht!")]
        [StringLength(75, ErrorMessage = "Naam mag maximaal 75 karakters zijn!")]
        public string Naam { get; set; }
    }
}
