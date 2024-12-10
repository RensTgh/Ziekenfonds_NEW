using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Opleiding
{
    public class UpdateOpleidingPersoonDto
    {
        [Required(ErrorMessage = "OpleidingId is verplicht!")]
        public int OpleidingId { get; set; }

        [Required(ErrorMessage = "PersoonId is verplicht!")]
        public string PersoonId { get; set; }
    }
}