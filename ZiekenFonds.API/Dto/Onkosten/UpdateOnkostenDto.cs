using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Dto.Onkosten
{
    public class UpdateOnkostenDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "GroepsreisId is verplicht!")]
        public int GroepsreisId { get; set; }

        [Required(ErrorMessage = "Titel is verplicht!")]
        [StringLength(50, ErrorMessage = "Titel mag maximaal 50 karakters lang zijn!")]
        public string Titel { get; set; }

        [Required(ErrorMessage = "Omschrijving is verplicht!")]
        [StringLength(200, ErrorMessage = "Omschrijving mag maximaal 200 karakters lang zijn!")]
        public string Omschrijving { get; set; }

        [Required(ErrorMessage = "Bedrag is verplicht!")]
        public float Bedrag { get; set; }

        [Required(ErrorMessage = "Datum is verplicht!")]
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        public string Foto { get; set; }
    }
}