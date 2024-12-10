namespace ZiekenFonds.API.Dto.Opleiding
{
    public class OpleidingResponseDto
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime Begindatum { get; set; }
        public DateTime Einddatum { get; set; }
    }
}