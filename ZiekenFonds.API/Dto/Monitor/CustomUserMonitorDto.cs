using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Monitor
{
    public class CustomUserMonitorDto
    {
        [PersonalData]
        [Required(ErrorMessage = "Naam is verplicht!")]
        [StringLength(50, ErrorMessage = "Naam mag maximaal 50 karakters lang zijn!")]
        public string Naam { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Voornaam is verplicht!")]
        [StringLength(50, ErrorMessage = "Voornaam mag maximaal 50 karakters lang zijn!")]
        public string Voornaam { get; set; }

        [PersonalData]
        public bool isHoofdMonitor { get; set; } = false;
    }
}