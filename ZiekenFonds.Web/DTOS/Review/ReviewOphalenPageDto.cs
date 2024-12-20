namespace ZiekenFonds.Web.DTOS.Review
{
    public class ReviewOphalenPageDto
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public int Score { get; set; }
        public string? PersoonId { get; set; }
        public int? BestemmingId { get; set; }
    }
}