using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZiekenFonds.API.Data;
using ZiekenFonds.API.Data.UnitOfWork;
using ZiekenFonds.API.Dto.Foto;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FotoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FotoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // 1. Foto Uploaden
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFoto([FromForm] UploadFotoDto dto)
        {
            if (dto.File == null || dto.File.Length == 0)
                return BadRequest("Het bestand is verplicht!");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var bestandspad = Path.Combine(uploadsFolder, dto.File.FileName);
            using (var stream = new FileStream(bestandspad, FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }

            var foto = new Foto
            {
                Naam = dto.Naam,
                BestemmingId = dto.BestemmingId
            };

            await _unitOfWork.FotoRepository.AddItemAsync(foto);
            await _unitOfWork.SaveChangesAsync();

            return Ok(foto);
        }



        // 2. Foto's ophalen voor een bestemming
        [HttpGet("/api/Foto/{bestemmingId}")]
        public async Task<IActionResult> GetFotosByBestemming(int bestemmingId)
        {
            var fotos = await _unitOfWork.FotoRepository.GetFotosByBestemming(bestemmingId);

            // Map naar FotoDto
            var fotosDto = _mapper.Map<IEnumerable<GetFotoDto>>(fotos);

            return Ok(fotosDto);
        }

        // 3. Foto Verwijderen
        [HttpDelete("/api/{id}")]
        public async Task<IActionResult> DeleteFoto(int id)
        {
            var foto = await _unitOfWork.FotoRepository.GetItemAsync(id);
            if (foto == null)
                return NotFound();

            if (!string.IsNullOrEmpty(foto.Naam) && System.IO.File.Exists(foto.Naam))
            {
                System.IO.File.Delete(foto.Naam);
            }

            _unitOfWork.FotoRepository.DeleteItem(foto);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
