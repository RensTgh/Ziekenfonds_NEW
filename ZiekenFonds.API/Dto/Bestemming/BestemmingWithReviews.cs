using System.ComponentModel.DataAnnotations;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Dto.Bestemming
{
    public class BestemmingWithReviews
    {
        public string Tekst { get; set; }

        public int Score { get; set; }
    }
}
