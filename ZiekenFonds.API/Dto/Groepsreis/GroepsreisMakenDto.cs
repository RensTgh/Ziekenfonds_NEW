using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Groepsreis
{
    public class GroepsreisMakenDto
    {
        [Required(ErrorMessage = "BestemmingId is verplicht!")]
        public int BestemmingId { get; set; }

        [Required(ErrorMessage = "Begindatum is verplicht!")]
        [DataType(DataType.Date)]
        public DateTime Begindatum { get; set; }

        [Required(ErrorMessage = "Einddatum is verplicht!")]
        [DataType(DataType.Date)]
        public DateTime Einddatum { get; set; }

        [Required(ErrorMessage = "Prijs is verplicht!")]
        public float Prijs { get; set; }

        //public List<int> ProgrammaIds { get; set; }
        public int[] ActiviteitIds { get; set; }
        //public List<int> KindIds { get; set; }
    }
}