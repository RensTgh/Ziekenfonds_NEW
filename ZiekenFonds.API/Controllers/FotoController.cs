using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

            var bestandsNaam = Path.GetFileName(dto.File.FileName);
            var bestandspad = Path.Combine(uploadsFolder, bestandsNaam);

            // Upload het bestand
            using (var stream = new FileStream(bestandspad, FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }

            // Maak het Foto-object
            var foto = new Foto
            {
                Naam = bestandsNaam,
                BestemmingId = dto.BestemmingId
            };

            // Voeg de foto toe aan de database
            await _unitOfWork.FotoRepository.AddItemAsync(foto);
            await _unitOfWork.SaveChangesAsync();

            var fotoDto = _mapper.Map<GetFotoDto>(foto);
            return Ok(fotoDto);
        }

        // 2. Foto's ophalen voor een bestemming
        [HttpGet("{bestemmingId}")]
        public async Task<IActionResult> GetFotosByBestemming(int bestemmingId)
        {
            var fotos = await _unitOfWork.FotoRepository.GetFotosByBestemming(bestemmingId);

            var fotosDto = fotos.Select(foto => new GetFotoDto
            {
                Id = foto.Id,
                Naam = foto.Naam,
                BestemmingNaam = foto.Bestemming?.Naam
            });

            return Ok(fotosDto);
        }

        // 3. Foto Verwijderen
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoto(int id)
        {
            var foto = await _unitOfWork.FotoRepository.GetItemAsync(id);
            if (foto == null)
                return NotFound();

            var bestandspad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", foto.Naam);
            if (System.IO.File.Exists(bestandspad))
            {
                System.IO.File.Delete(bestandspad);
            }

            _unitOfWork.FotoRepository.DeleteItem(foto);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}