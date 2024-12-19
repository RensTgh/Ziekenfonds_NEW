namespace ZiekenFonds.API.Dto.Kind
{
    public class RegisterForGroepsreisDto
    {
        public int KindId { get; set; }
        public int GroepsReisId { get; set; }
        public string? Opmerking { get; set; } // Optioneel, gebruiker kan deze leeg laten
        public string? ContractNummer { get; set; } // Optioneel
    }
}
