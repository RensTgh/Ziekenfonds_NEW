using Microsoft.AspNetCore.Mvc;
using ZiekenFonds.Web.Services;
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

            var model = new UploadFotoDto
            {
                BestemmingId = bestemmingId
            };

            return View(model);
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
    }

}
