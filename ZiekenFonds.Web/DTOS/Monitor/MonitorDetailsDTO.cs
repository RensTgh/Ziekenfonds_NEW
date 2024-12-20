namespace ZiekenFonds.Web.DTOS.Monitor
{
    public class MonitorDetailsDTO
    {
        public string Naam { get; set; }
        public IEnumerable<string> Opleidingen { get; set; }
        public IEnumerable<string> Bestemmingen { get; set; }
    }
}