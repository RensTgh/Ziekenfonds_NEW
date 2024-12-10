using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ziekenfonds.MVC.DTOS;
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
            ActiveitenDTO activeitenDTO = await _service.GetActivityAsync(1);

            return View(activeitenDTO);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}