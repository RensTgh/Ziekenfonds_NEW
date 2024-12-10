using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Bestemming
{
    public class BestemmingWithGroepsreis
    {
        public DateTime Begindatum { get; set; }
        public DateTime Einddatum { get; set; }
        public float Prijs { get; set; }
    }
}
