using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.Web.DTOS.Opleiding
{
    public class OpleidingPersoonInschrijvingDto
    {
        [Required]
        public int OpleidingId { get; set; }

        [Required]
        public string PersoonId { get; set; }
    }
}