namespace ZiekenFonds.Web.DTOS.Deelnemer
{
    public class DeelnemerInfoDTO
    {
        public string Omschrijving { get; set; }
        public string DeelnemerNaam { get; set; }
        public int Leeftijd { get; set; }
        public string? Allergieën { get; set; }
        public string? Medicatie { get; set; }
        public string NaamVoogd { get; set; }
        public string Telefoonnummer { get; set; }
    }
}