using Microsoft.AspNetCore.Mvc;
using ZiekenFonds.Web.DTOS.Monitor;
using ZiekenFonds.Web.Services;

namespace ZiekenFonds.Web.Controllers
{
    public class MonitorController : Controller
    {
        private IMonitorService _monitorService;

        public MonitorController(IMonitorService monitorService)
        {
            _monitorService = monitorService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            MonitorGegevensDTO[] monitorDTO = await _monitorService.GetAllMonitorsWithDetailsAsync();
            return View(monitorDTO);
        }
    }
}