using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ziekenfonds.MVC.DTOS;
using ZiekenFonds.Web.Models;
using ZiekenFonds.Web.Services;

namespace Ziekenfonds.MVC.Controllers
{
    public class ActiviteitenController : Controller
    {
        private readonly IActiviteitenService _service;

        public ActiviteitenController(IActiviteitenService service)
        {
            _service = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ActiveitenDTO activeitenDTO = await _service.GetActivityAsync(1);

            return View(activeitenDTO);
        }

    }
}