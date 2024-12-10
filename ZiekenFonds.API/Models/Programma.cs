using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Models
{
    public class Programma
    {

        [Required(ErrorMessage = "ActiviteitId is verplicht!")]
        public int ActiviteitId { get; set; }

        [Required(ErrorMessage = "GroepsreisId is verplicht!")]
        public int GroepsreisId { get; set; }
        
        // Relaties
        public Activiteit Activiteit { get; set; }
        public Groepsreis Groepsreis { get; set; }
    }
}