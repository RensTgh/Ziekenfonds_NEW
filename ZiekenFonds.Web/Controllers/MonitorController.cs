using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZiekenFonds.Web.DTOS.Monitor;
using ZiekenFonds.Web.Models;
using ZiekenFonds.Web.Services;

public class MonitorController : Controller
{
    private readonly ILogger<MonitorController> _logger;
    private readonly IMonitorService _service;

    public MonitorController(ILogger<MonitorController> logger, IMonitorService service)
    {
        _logger = logger;
        _service = service;
    }

    public async Task<IActionResult> IndexAsync()
    {
        MonitorGegevensDTO[] monitorDTO = await _service.GetAllMonitorsWithDetailsAsync();
        return View(monitorDTO);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public IActionResult Create() // Voor de weergave van het formulier
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMonitorDTO dto) // Voor het verzenden van gegevens
    {
        if (!ModelState.IsValid)
        {
            return View(dto); // Valideer het formulier
        }

        try
        {
            await _service.CreateMonitorAsync(dto);
            return RedirectToAction(nameof(IndexAsync));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Fout bij het aanmaken van een monitor");
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
