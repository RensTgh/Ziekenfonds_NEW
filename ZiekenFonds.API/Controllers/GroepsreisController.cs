using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using ZiekenFonds.API.Data.UnitOfWork;
using ZiekenFonds.API.Dto.Groepsreis;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroepsreisController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GroepsreisController(IUnitOfWork context, IMapper mapper)
        {
            _uow = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<GroepsreisOphalenDto>> GetGroepsreizen()
        {
            IEnumerable<Groepsreis> groepreizen = await _uow.GroepsReisRepository.GetCompleteGroepsReizenAsync();

            List<GroepsreisOphalenDto> dtos = _mapper.Map<List<GroepsreisOphalenDto>>(groepreizen);

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroepsreisOphalenDto>> GetGroepsreis(int id)
        {
            Groepsreis groepsreis = await _uow.GroepsReisRepository.GetCompleteGroepsReis(id);

            if (groepsreis == null)
            {
                return NotFound("Er is geen groepsreis gevonden met deze id");
            }

            GroepsreisOphalenDto dto = _mapper.Map<GroepsreisOphalenDto>(groepsreis);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<GroepsreisMakenDto>> GroepsreisToevoegen(GroepsreisMakenDto dto)
        {
            // Validatie
            if (_uow.GroepsReisRepository == null)
                return NotFound("De table 'Groepsreis' bestaat niet in de database");

            if (_uow.ActiviteitenRepository == null)
                return NotFound("De table 'Activiteit' bestaat niet in de database");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Groepsreis groepsreis = _mapper.Map<Groepsreis>(dto);

            // Valideer en add Bestemming

            using (IDbContextTransaction transaction = _uow.BeginTransaction())
            {
                try
                {
                    // Transactie: als één van de commando's niet lukt worden de vorige ongedaan gemaakt
                    await _uow.GroepsReisRepository.AddItemAsync(groepsreis);
                    await _uow.SaveChangesAsync();

                    await _uow.ActiviteitenRepository.VoegActiviteitenToeAanReis(groepsreis.Id, dto.ActiviteitIds);
                    await _uow.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

            // Voeg activiteiten toe aan reis

            return CreatedAtAction(nameof(GroepsreisToevoegen), null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroepsreis(int id, UpdateGroepsreisDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingGroepsreis = await _uow.GroepsReisRepository.GetItemAsync(id);
            if (existingGroepsreis == null)
            {
                return NotFound("Er is geen groepsreis met dit id gevonden");
            }

            _mapper.Map(dto, existingGroepsreis);

            if (dto.ActiviteitIds == null || !dto.ActiviteitIds.Any())
            {
                return BadRequest("ActiviteitIds mogen niet leeg zijn.");
            }

            using (IDbContextTransaction transaction = _uow.BeginTransaction())
            {
                try
                {
                    await _uow.ActiviteitenRepository.VerwijderActiviteitenVanReis(existingGroepsreis.Id);
                    _uow.GroepsReisRepository.UpdateItem(existingGroepsreis);
                    await _uow.ActiviteitenRepository.VoegActiviteitenToeAanReis(existingGroepsreis.Id, dto.ActiviteitIds);
                    await _uow.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GroepsreisVerwijderen(int id)
        {
            if (_uow.GroepsReisRepository == null)
            {
                return NotFound("De tabel groepsreis bestaat niet.");
            }

            var groep = await _uow.GroepsReisRepository.GetItemAsync(id);
            if (groep == null)
            {
                return NotFound("De groepsreis met deze id is niet gevonden.");
            }

            // Delete related programmas
            await _uow.ActiviteitenRepository.VerwijderActiviteitenVanReis(groep.Id);

            // Delete de groepsreis
            _uow.GroepsReisRepository.DeleteItem(groep);

            await _uow.SaveChangesAsync();

            return Ok($"Groepsreis met id {id} is verwijderd.");
        }
    }
}