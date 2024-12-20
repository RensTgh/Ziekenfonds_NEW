using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZiekenFonds.Web.DTOS.Opleiding
{
    public class OpleidingOphalenDto
    {
        public List<OpleidingDto> Opleidingen { get; set; }
        public int MonitorID { get; set; } // Geselecteerde monitor

        public List<SelectListItem> AlleMonitors { get; set; }

        public OpleidingPersoonInschrijvingDto OpleidingPersoonInschrijvingDto { get; set; }
    }
}