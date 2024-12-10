namespace ZiekenFonds.API.Dto.Opleiding
{
    public class OpleidingWithPersonenDto
    {
        public string Naam { get; set; }

        public string Beschrijving { get; set; }

        public DateTime Begindatum { get; set; }

        public DateTime Einddatum { get; set; }

        public int AantalPlaatsen { get; set; }

        public List<OpleidingPersoonDto> OpleidingenPersonen { get; set; }
        public List<VoorOpleidingDto> VereisteOpleidingen { get; set; }
    }
}