using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Dto.Monitor
{
    public class GetMonitorDetailsDto
    {
        public string Naam { get; set; }
        public IEnumerable<string> Opleidingen { get; set; }
        public IEnumerable<string> Bestemmingen { get; set; }
    }
}

