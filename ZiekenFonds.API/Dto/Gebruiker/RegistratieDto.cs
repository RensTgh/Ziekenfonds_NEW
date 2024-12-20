using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Gebruiker
{
    public class RegistratieDto
    {
        [Required(ErrorMessage = "Naam is verplicht!")]
        [StringLength(50, ErrorMessage = "Naam mag maximaal 50 karakters lang zijn!")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht!")]
        [StringLength(50, ErrorMessage = "Voornaam mag maximaal 50 karakters lang zijn!")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Straat is verplicht!")]
        [StringLength(50, ErrorMessage = "Straat mag maximaal 50 karakters lang zijn!")]
        public string Straat { get; set; }

        [Required(ErrorMessage = "Huisnummer is verplicht!")]
        [StringLength(5, ErrorMessage = "Huisnummer mag maximaal 5 karakters lang zijn!")]
        public string Huisnummer { get; set; }

        [Required(ErrorMessage = "Gemeente is verplicht!")]
        [StringLength(50, ErrorMessage = "Gemeente mag maximaal 50 karakters lang zijn!")]
        public string Gemeente { get; set; }

        [Required(ErrorMessage = "Postcode is verplicht!")]
        [StringLength(6, ErrorMessage = "Postcode mag maximaal 6 karakters lang zijn!")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Geboortedatum is verplicht!")]
        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }

        [Required(ErrorMessage = "Huisdokter is verplicht!")]
        [StringLength(50, ErrorMessage = "Huisdokter mag maximaal 50 karakters lang zijn!")]
        public string Huisdokter { get; set; }

        public string ContractNummer { get; set; }

        public bool isHoofdMonitor { get; set; } = false;

        [Required(ErrorMessage = "Telefoonnummer is verplicht!")]
        [StringLength(50, ErrorMessage = "Telefoonnummer mag maximaal 50 karakters lang zijn!")]
        public string TelefoonNummer { get; set; }

        [StringLength(50, ErrorMessage = "Rekeningnummer mag maximaal 50 karakters lang zijn!")]
        public string RekeningNummer { get; set; }

        [Required]
        public bool IsActief { get; set; } = false;

        [Required(ErrorMessage = "Email is verplicht!")]
        [StringLength(50, ErrorMessage = "Email mag maximaal 50 karakters lang zijn!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is verplicht!")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Tweede wachtwoord is verplicht in te vullen.")]
        [Compare("Password", ErrorMessage = "De wachtwoorden komen niet overeen.")]
        public string ConfirmPassword { get; set; } = "";
    }
}