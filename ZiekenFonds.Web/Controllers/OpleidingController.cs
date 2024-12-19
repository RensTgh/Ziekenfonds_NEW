using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZiekenFonds.Web.DTOS.Opleiding;
using ZiekenFonds.Web.Models;
using ZiekenFonds.Web.Services.Opleiding;

namespace ZiekenFonds.Web.Controllers
{
    public class OpleidingController : Controller
    {
        private readonly ILogger<OpleidingController> _logger;
        private readonly IOpleidingServices _service;

        public OpleidingController(ILogger<OpleidingController> logger, IOpleidingServices service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                // Fetch alle opleidingen uit de service
                var allOpleidingen = await _service.GetAllOpleidingenAsync();

                // Initialiseer de DTO met de opgehaalde gegevens
                var model = new CreateOpleidingPageDto
                {
                    Begindatum = DateTime.Today, // Default date zodat deze niet op 01/01/0001 komt te staan
                    Einddatum = DateTime.Today.AddDays(30),
                    AllOpleidingen = allOpleidingen.ToList()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching opleidingen for Create form");

                // Optioneel, stuur door naar een foutpagina of retourneer een basisweergave met een foutmelding
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOpleidingPageDto dto)
        {
            if (!ModelState.IsValid)
            {
                dto.AllOpleidingen = (await _service.GetAllOpleidingenAsync()).ToList();
                return View(dto);
            }

            try
            {
                await _service.CreateOpleidingAsync(dto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Opleiding");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the Opleiding.");
                dto.AllOpleidingen = (await _service.GetAllOpleidingenAsync()).ToList();
                return View(dto);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Id check
            if (id <= 0)
            {
                _logger.LogWarning($"Invalid ID attempted for deletion: {id}");
                return RedirectToAction("Index");
            }

            try
            {
                // Probeer te verwijderen
                await _service.DeleteOpleiding(id);

                // Add een TempData message voor als de delete werkt
                TempData["SuccessMessage"] = "Opleiding successfully deleted.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            // Stuur de gebruiker terug naar de home page
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                // Fetch all opleidingen
                OpleidingOphalenDto[] opleidingen = await _service.GetAllOpleidingenAsync();

                // Fetch all monitors
                OpleidingMonitorPageDto[] allMonitors = await _service.GetAllMonitorsAsync();

                if (allMonitors != null)
                {
                    foreach (var opleiding in opleidingen)
                    {
                        opleiding.AllMonitors = allMonitors.ToList();
                    }
                }

                return View(opleidingen);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching opleidingen and monitors for Index");

                // Return een error ??
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Inschrijven(int opleidingId, string persoonId)
        {
            if (opleidingId <= 0 || string.IsNullOrEmpty(persoonId))
            {
                TempData["ErrorMessage"] = "OpleidingId en PersoonId zijn vereist.";
                return RedirectToAction("Index");
            }

            try
            {
                await _service.InschrijvenAsync(opleidingId, persoonId);
                TempData["SuccessMessage"] = "Succesvol ingeschreven.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Er is een fout opgetreden: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}