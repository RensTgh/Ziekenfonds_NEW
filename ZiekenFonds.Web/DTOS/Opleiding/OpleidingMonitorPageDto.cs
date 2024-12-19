namespace ZiekenFonds.Web.DTOS.Opleiding
{
    public class OpleidingMonitorPageDto
    {
        public int Id { get; set; }
        public string PersoonId { get; set; }  
        public int GroepsreisId { get; set; }
        public bool IsHoofdMonitor { get; set; }
        public object Persoon { get; set; }  
        public object Groepsreis { get; set; }  
    }
}