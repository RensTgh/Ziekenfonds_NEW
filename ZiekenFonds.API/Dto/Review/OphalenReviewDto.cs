using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Review
{
    public class OphalenReviewDto
    {
        public string Tekst { get; set; }
        [Required(ErrorMessage = "Score is verplicht!")]

        public int Score { get; set; }

        public string PersoonId { get; set; }

        public int BestemmingId { get; set; }
    }
}
