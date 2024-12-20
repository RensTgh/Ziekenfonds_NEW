using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Models
{
    public class CustomUser : IdentityUser
    {
        [PersonalData]
        public string Id { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Naam is verplicht!")]
        [StringLength(50, ErrorMessage = "Naam mag maximaal 50 karakters lang zijn!")]
        public string Naam { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Voornaam is verplicht!")]
        [StringLength(50, ErrorMessage = "Voornaam mag maximaal 50 karakters lang zijn!")]
        public string Voornaam { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Straat is verplicht!")]
        [StringLength(50, ErrorMessage = "Straat mag maximaal 50 karakters lang zijn!")]
        public string Straat { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Huisnummer is verplicht!")]
        [StringLength(5, ErrorMessage = "Huisnummer mag maximaal 5 karakters lang zijn!")]
        public string Huisnummer { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Gemeente is verplicht!")]
        [StringLength(50, ErrorMessage = "Gemeente mag maximaal 50 karakters lang zijn!")]
        public string Gemeente { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Postcode is verplicht!")]
        [StringLength(6, ErrorMessage = "Postcode mag maximaal 6 karakters lang zijn!")]
        public string Postcode { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Geboortedatum is verplicht!")]
        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Huisdokter is verplicht!")]
        [StringLength(50, ErrorMessage = "Huisdokter mag maximaal 50 karakters lang zijn!")]
        public string Huisdokter { get; set; }

        [PersonalData]
        public string ContractNummer { get; set; }

        [PersonalData]
        [Required(ErrorMessage = "Email is verplicht!")]
        [StringLength(50, ErrorMessage = "Email mag maximaal 50 karakters lang zijn!")]
        public string Email { get; set; }

        [PersonalData]
        public bool isHoofdMonitor { get; set; } = false;

        [PersonalData]
        [Required(ErrorMessage = "Telefoonnummer is verplicht!")]
        [StringLength(50, ErrorMessage = "Telefoonnummer mag maximaal 50 karakters lang zijn!")]
        public string TelefoonNummer { get; set; }

        [PersonalData]
        [StringLength(50, ErrorMessage = "Rekeningnummer mag maximaal 50 karakters lang zijn!")]
        public string RekeningNummer { get; set; }

        [PersonalData]
        [Required]
        public bool IsActief { get; set; } = false;

        // Relaties
        public List<Monitor> Monitors { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Kind> Kinderen { get; set; }
        public List<OpleidingPersoon> OpleidingenPersonen { get; set; }
    }
}