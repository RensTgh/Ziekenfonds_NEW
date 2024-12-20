using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.Web.DTOS.Review
{
    public class CreateReviewPageDto
    {
        public int BestemmingId { get; set; }

        public string? PersoonId { get; set; }

        [Required(ErrorMessage = "Tekst is verplicht!")]
        [StringLength(200)]
        public string Tekst { get; set; }

        [Required(ErrorMessage = "Score is verplicht!")]
        [Range(0, 5)]
        public int Score { get; set; }

        public List<SelectListItem>? Bestemmingen { get; set; }
    }
}