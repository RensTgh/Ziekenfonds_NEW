using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.Web.DTOS
{
    public class CreateActiviteitDTO
    {
        [Required(ErrorMessage = "De naam is verplicht.")]
        [StringLength(50, ErrorMessage = "De naam mag maximaal 50 karakters zijn.")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Beschrijving is verplicht!")]
        [StringLength(100, ErrorMessage = "Beschrijving mag maximaal 100 karakters lang zijn!")]
        public string Beschrijving { get; set; }
    }
}
