using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZiekenFonds.API.Data.UnitOfWork;
using ZiekenFonds.API.Dto.Onkosten;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OntkostenController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OntkostenController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetOnkostenDto>>> GetOnkosten()
        {
            var onkosten = await _unitOfWork.OnkostenRepository.GetAllItemsAsync();

            List<GetOnkostenDto> dto = _mapper.Map<List<GetOnkostenDto>>(onkosten);

            return Ok(dto.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetOnkostenDto>> GetOnkost(int id)
        {
            Onkosten onkosten = await _unitOfWork.OnkostenRepository.GetItemAsync(id);

            if (onkosten == null)
            {
                return NotFound("Er is geen activiteit gevonden met deze id");
            }

            GetOnkostenDto dto = _mapper.Map<GetOnkostenDto>(onkosten);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<CreateOnkostenDto>> OnkostToevoegen(CreateOnkostenDto onkostenAanmaken)
        {
            //Validatie
            if (_unitOfWork.OnkostenRepository == null)
                return NotFound("De tabel activiteit bestaat niet in de database.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Onkosten onkost = _mapper.Map<Onkosten>(onkostenAanmaken);

            //Job toevoegen aan de DbSet
            await _unitOfWork.OnkostenRepository.AddItemAsync(onkost);
            try
            {
                //Job wegschrijven naar de database
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException dbError)
            {
                return BadRequest(dbError);
            }

            return CreatedAtAction(nameof(OnkostToevoegen), new { id = onkost.Id }, onkost);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> OnkostWijzigen(int id, UpdateOnkostenDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("De opgegeven id's komen niet overeen.");
            }

            Onkosten existingOnkost = _mapper.Map<Onkosten>(dto);

            if (existingOnkost == null)
            {
                return NotFound("De onkosten die je wil wijzigen, komt niet voor in de database.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.OnkostenRepository.UpdateItem(existingOnkost);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_unitOfWork.OnkostenRepository.GetItemAsync(id).Result != null)
                {
                    return NotFound("Er is geen activiteit met dit id gevonden");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> OnkostVerwijderen(int id)
        {
            if (_unitOfWork.OnkostenRepository == null)
            {
                return NotFound("De tabel activiteit bestaat niet.");
            }

            var onkost = await _unitOfWork.OnkostenRepository.GetItemAsync(id);
            if (onkost == null)
            {
                return NotFound("De activiteit met deze id is niet gevonden.");
            }

            _unitOfWork.OnkostenRepository.DeleteItem(onkost);
            await _unitOfWork.SaveChangesAsync();

            return Ok($"Activiteit met id {id} is verwijderd");
        }
    }
}