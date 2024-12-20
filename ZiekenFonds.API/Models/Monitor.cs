using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Models
{
    public class Monitor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "PersoonId is verplicht!")]
        public string PersoonId { get; set; }

        [Required(ErrorMessage = "GroepsreisId is verplicht!")]
        public int GroepsreisId { get; set; }

        public bool IsHoofdMonitor { get; set; } // staat fout in ERD, moet overeenkomen met CustomUser.cs

        // Relaties
        public CustomUser Persoon { get; set; }

        public Groepsreis Groepsreis { get; set; }
    }
}