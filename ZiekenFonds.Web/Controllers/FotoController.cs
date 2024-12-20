using Microsoft.AspNetCore.Mvc;
using ZiekenFonds.Web.DTOS;
using ZiekenFonds.Web.Services;
using ZiekenFonds.MVC.Dtos;
using ZiekenFonds.Web.DTOS.Foto;

namespace ZiekenFonds.Web.Controllers
{
    public class FotoController : Controller
    {
        private readonly IFotoService _fotoService;

        public FotoController(IFotoService fotoService)
        {
            _fotoService = fotoService;
        }

        // 1. Haal foto's op en toon ze
        public async Task<IActionResult> Index(int bestemmingId)
        {
            if (bestemmingId <= 0)
                return BadRequest("Invalid Bestemming ID.");

            try
            {
                var fotos = await _fotoService.GetAllFotosAsync(bestemmingId);
                ViewBag.BestemmingId = bestemmingId;
                return View(fotos);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Failed to load Fotos: {ex.Message}");
                return View(Enumerable.Empty<GetFotoDto>());
            }
        }

        // 2. Toon upload formulier
        [HttpGet]
        public IActionResult Upload(int bestemmingId)
        {
            if (bestemmingId <= 0)
                return BadRequest("Invalid Bestemming ID.");

            ViewBag.BestemmingId = bestemmingId;
            return View();
        }

        // 3. Verwerk foto-upload
        [HttpPost]
        public async Task<IActionResult> Upload(UploadFotoDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BestemmingId = dto.BestemmingId;
                return View(dto);
            }

            try
            {
                await _fotoService.UploadFotoAsync(dto);
                return RedirectToAction("Index", new { bestemmingId = dto.BestemmingId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Failed to upload Foto: {ex.Message}");
                ViewBag.BestemmingId = dto.BestemmingId;
                return View(dto);
            }
        }

        // 4. Verwijder een foto
        [HttpPost]
        public async Task<IActionResult> Delete(int id, int bestemmingId)
        {
            if (id <= 0 || bestemmingId <= 0)
                return BadRequest("Invalid Foto or Bestemming ID.");

            try
            {
                await _fotoService.DeleteFotoAsync(id);
                return RedirectToAction("Index", new { bestemmingId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Failed to delete Foto: {ex.Message}");
                return RedirectToAction("Index", new { bestemmingId });
            }
        }
    }
}
