using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Monitor
{
    public class UpdateMonitorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Een datum en tijd is verplicht")]
        public string PersoonId { get; set; }

        [Required(ErrorMessage = "Je moet een email meegeven van een tandarts")]
        public int GroepsreisId { get; set; }

        [Required(ErrorMessage = "Verplicht aan te duiden of monitor hoodmonitor is")]
        public bool IsHoofdMonitor { get; set; }

    }
}
