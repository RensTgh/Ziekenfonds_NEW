using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using ZiekenFonds.API.Data.UnitOfWork;
using ZiekenFonds.API.Dto.Activiteit;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiviteitController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public ActiviteitController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Get all
        [HttpGet]
        public async Task<ActionResult<ActiviteitOphalenDto>> GetActiviteiten()
        {
            IEnumerable<Activiteit> activiteiten = await _context.ActiviteitenRepository.GetAllItemsAsync();

            List<ActiviteitOphalenDto> dtos = _mapper.Map<List<ActiviteitOphalenDto>>(activiteiten);

            return Ok(dtos);
        }

        // Get by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ActiviteitOphalenDto>> GetActiviteit(int id)
        {
            Activiteit activiteit = await _context.ActiviteitenRepository.GetItemAsync(id);

            if (activiteit == null)
            {
                return NotFound("Er is geen activiteit gevonden met deze id");
            }

            ActiviteitOphalenDto dto = _mapper.Map<ActiviteitOphalenDto>(activiteit);

            return Ok(dto);
        }

        // Add
        [HttpPost]
        public async Task<ActionResult<ActiviteitMakenDto>> ActiviteitToevoegen(ActiviteitMakenDto activiteitAanmakenDto)
        {
            //Validatie
            if (_context.ActiviteitenRepository == null)
                return NotFound("De tabel activiteit bestaat niet in de database.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Activiteit activiteit = _mapper.Map<Activiteit>(activiteitAanmakenDto);

            //Job toevoegen aan de DbSet
            await _context.ActiviteitenRepository.AddItemAsync(activiteit);
            try
            {
                //Job wegschrijven naar de database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbError)
            {
                return BadRequest(dbError);
            }

            return CreatedAtAction(nameof(GetActiviteit), new { id = activiteit.Id }, activiteit);
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> ActiviteitVerwijderen(int id)
        {
            if (_context.ActiviteitenRepository == null)
            {
                return NotFound("De tabel activiteit bestaat niet.");
            }

            var activiteit = await _context.ActiviteitenRepository.GetItemAsync(id);
            if (activiteit == null)
            {
                return NotFound("De activiteit met deze id is niet gevonden.");
            }

            _context.ActiviteitenRepository.DeleteItem(activiteit);
            await _context.SaveChangesAsync();

            return Ok($"Activiteit met id {id} is verwijderd");
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> ActiviteitWijzigen(int id, ActiviteitUpdateDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("De opgegeven id's komen niet overeen.");
            }

            Activiteit existingActiviteit = _mapper.Map<Activiteit>(dto);

            if (existingActiviteit == null)
            {
                return NotFound("De activiteit die je wil wijzigen, komt niet voor in de database.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ActiviteitenRepository.UpdateItem(existingActiviteit);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.ActiviteitenRepository.GetItemAsync(id).Result != null)
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
    }
}