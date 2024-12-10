using System.ComponentModel.DataAnnotations;

namespace ZiekenFonds.API.Models
{
    public class OpleidingPersoon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "OpleidingId is verplicht!")]
        public int OpleidingId { get; set; }

        [Required(ErrorMessage = "PersoonId is verplicht!")]
        public string PersoonId { get; set; }

        // Relaties
        public Opleiding Opleiding { get; set; }
        public CustomUser Persoon {  get; set; }
    }
}