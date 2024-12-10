using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Groepsreis
{
    public class GroepsreisOphalenDto
    {
        public int Id { get; set; }

        public int BestemmingId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Begindatum { get; set; }

        [DataType(DataType.Date)]
        public DateTime Einddatum { get; set; }

        public float Prijs { get; set; }

        public string Bestemming { get; set; }

        public List<GroepsreisDeelnemerOphalenDto> Deelnemers { get; set; }
        public List<GroepsreisProgrammaDto> Programmas { get; set; }
    }
}