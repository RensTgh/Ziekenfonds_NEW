using Microsoft.AspNetCore.Mvc;
using Ziekenfonds.MVC.DTOS;
using ZiekenFonds.Web.DTOS.Deelnemer;
using ZiekenFonds.Web.Services.Deelnemers;
using ZiekenFonds.Web.Services.Opleiding;

namespace ZiekenFonds.Web.Controllers
{
    public class DeelnemerController : Controller
    {
        private readonly ILogger<DeelnemerController> _logger;
        private readonly IDeelnemerService _service;

        public DeelnemerController(ILogger<DeelnemerController> logger, IDeelnemerService service)
        {
            _logger = logger;
            _service = service;
        }


        public async Task<IActionResult> Index()
        {

            DeelnemersVanReisOphalenDTO[] dto = await _service.GetAllDeelnemersVanReis();

            return View(dto);
        }
    }
}
