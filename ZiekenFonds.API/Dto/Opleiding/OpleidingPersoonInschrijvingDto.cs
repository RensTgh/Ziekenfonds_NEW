using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Opleiding
{
    public class OpleidingPersoonInschrijvingDto
    {
        [Required]
        public int OpleidingId { get; set; }

        [Required]
        public string PersoonId { get; set; }
    }
}