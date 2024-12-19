using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Gebruiker
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is verplicht.")]
        [EmailAddress(ErrorMessage = "Ongeldig emailadres.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
    }
}