using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ziekenfonds.MVC.DTOS;
using ZiekenFonds.Web.DTOS;
using ZiekenFonds.Web.Models;
using ZiekenFonds.Web.Services;

namespace Ziekenfonds.MVC.Controllers
{
    public class ActiviteitenController : Controller
    {
        private readonly ILogger<ActiviteitenController> _logger;
        private readonly IActiviteitenService _service;

        public ActiviteitenController(ILogger<ActiviteitenController> logger, IActiviteitenService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ActiviteitenDTO[] activeitenDTO = await _service.GetAllActiviteitenAsync();

            return View(activeitenDTO);
        }

        // Toon de vorm om een activiteit toe te voegen

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                // Fetch alle opleidingen uit de service
                var allActiviteiten = await _service.GetAllActiviteitenAsync();

                var model = new CreateActiviteitDTO
                {

                };

                return View(model);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching activiteiten for Create form");

                // Optioneel, stuur door naar een foutpagina of retourneer een basisweergave met een foutmelding
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActiviteitDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                await _service.CreateActiviteitAsync(dto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Activiteit");
                ModelState.AddModelError(string.Empty, "An error occurred while creating the Activiteit.");
                return View(dto);
            }
        }

        // Verwijder een activiteit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Id check
                if (id <= 0)
                {
                    _logger.LogWarning($"Invalid ID attempted for deletion: {id}");
                    return RedirectToAction("Index");
                }

                // Probeer te verwijderen
                await _service.DeleteActivityAsync(id);

                // Add een TempData message voor als de delete werkt
                TempData["SuccessMessage"] = "Activiteit successfully deleted.";

                // Stuur de gebruiker terug naar de home page
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting Activiteit with ID: {id}");

                // Add een TempData message voor als de delete niet werkt
                TempData["ErrorMessage"] = "An error occurred while trying to delete the Activiteit.";

                // Stuur de gebruiker terug naar de home page
                return RedirectToAction("Index");
            }
        }
    }
}