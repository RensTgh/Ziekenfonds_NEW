using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using ZiekenFonds.Web.DTOS.Opleiding;
using ZiekenFonds.Web.DTOS.Review;
using ZiekenFonds.Web.Models;
using ZiekenFonds.Web.Services.Bestemming;
using ZiekenFonds.Web.Services.Opleiding;
using ZiekenFonds.Web.Services.Review;

namespace ZiekenFonds.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewServices _reviewService;

        private readonly IBestemmingService _bestemmingService;

        //private readonly UserManager<CustomUser> _userManager;

        public ReviewController(ILogger<ReviewController> logger, IReviewServices service, IBestemmingService bestemmingService)
        {
            _logger = logger;
            _reviewService = service;
            _bestemmingService = bestemmingService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ReviewOphalenPageDto[] dto = await _reviewService.GetAllReviewsAsync();
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                CreateReviewPageDto dto = new CreateReviewPageDto();
                var bestemmingen = await _bestemmingService.GetAllBestemmingenAsync();
                dto.Bestemmingen = bestemmingen.Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Naam
                }).ToList();

                return View(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewPageDto dto)
        {
            dto.PersoonId = "user1";  // Hier gebruik je de unieke gebruikers-ID

            if (ModelState.IsValid)
            {
                //CustomUser? user = await _userManager.GetUserAsync(User); // User is de huidige geauthenticeerde gebruiker
                await _reviewService.CreateReviewAsync(dto);
            }

            var bestemmingen = await _bestemmingService.GetAllBestemmingenAsync();
            dto.Bestemmingen = bestemmingen.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Naam
            }).ToList();

            return View(dto);
        }
    }
}