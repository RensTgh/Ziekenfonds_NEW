using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.Web.DTOS.Deelnemer
{
    public class DeelnemersVanReisOphalenDTO
    {
        public int Id { get; set; }

        public int BestemmingId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Begindatum { get; set; }

        [DataType(DataType.Date)]
        public DateTime Einddatum { get; set; }

        public float Prijs { get; set; }

        public string Bestemming { get; set; }

        public List<DeelnemerInfoDTO> Deelnemers { get; set; }
    }
}