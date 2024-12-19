using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZiekenFonds.API.Data.Repository;
using ZiekenFonds.API.Data.UnitOfWork;
using ZiekenFonds.API.Dto.Kind;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KindController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public KindController(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Get all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetKind>>> GetKinderen()
        {
            IEnumerable<Kind> kinderen = await _context.KindRepository.GetAllItemsAsync();

            List<GetKind> dtos = _mapper.Map<List<GetKind>>(kinderen);

            return Ok(dtos);
        }

        // Get by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<GetKind>> GetKind(int id)
        {
            Kind kind = await _context.KindRepository.GetItemAsync(id);

            if (kind == null)
            {
                return NotFound("Er is geen kind gevonden met deze id");
            }

            GetKind dto = _mapper.Map<GetKind>(kind);

            return Ok(dto);
        }

        // Add
        [HttpPost]
        public async Task<ActionResult> KindToevoegen(CreateKind kindMakenDto)
        {
            // Validatie
            if (_context.KindRepository == null)
                return NotFound("De tabel kind bestaat niet in de database.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Kind kind = _mapper.Map<Kind>(kindMakenDto);

            // Kind toevoegen aan de DbSet
            await _context.KindRepository.AddItemAsync(kind);
            try
            {
                // Kind wegschrijven naar de database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbError)
            {
                return BadRequest(dbError.InnerException.Message);
            }

            return CreatedAtAction(null, null);
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> KindVerwijderen(int id)
        {
            if (_context.KindRepository == null)
            {
                return NotFound("De tabel kind bestaat niet.");
            }

            var kind = await _context.KindRepository.GetItemAsync(id);
            if (kind == null)
            {
                return NotFound("Het kind met deze id is niet gevonden.");
            }

            _context.KindRepository.DeleteItem(kind);
            await _context.SaveChangesAsync();

            return Ok($"Kind met id {id} is verwijderd");
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> KindWijzigen(int id, UpdateKind dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("De opgegeven id's komen niet overeen.");
            }

            var kind = await _context.KindRepository.GetItemAsync(id);

            if (kind == null)
            {
                return NotFound("Het kind dat je wil wijzigen, komt niet voor in de database.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(dto, kind);

            _context.KindRepository.UpdateItem(kind);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.KindRepository.GetItemAsync(id) == null)
                {
                    return NotFound("Er is geen kind met dit id gevonden");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("RegisterForGroepsreis")]
        public async Task<ActionResult> RegisterForGroepsreis([FromBody] RegisterForGroepsreisDto dto)
        {
            var kind = await _context.KindRepository.GetItemAsync(dto.KindId);
            var groepsReis = await _context.GroepsReisRepository.GetCompleteGroepsReis(dto.GroepsReisId);

            if (kind == null || groepsReis == null)
            {
                return NotFound("Kind of Groepsreis niet gevonden.");
            }

            // Bereken de leeftijd van het kind
            int leeftijd = DateTime.Now.Year - kind.Geboortedatum.Year;
            if (kind.Geboortedatum.Date > DateTime.Now.AddYears(-leeftijd)) leeftijd--;

            // Controleer of de leeftijd binnen de limieten valt
            if (leeftijd < groepsReis.Bestemming.MinLeeftijd || leeftijd > groepsReis.Bestemming.MaxLeeftijd)
            {
                return BadRequest("De leeftijd van het kind valt niet binnen de toegestane leeftijdsgrens van de groepsreis.");
            }

            // Maak een nieuwe Deelnemer aan
            var deelnemer = new Deelnemer
            {
                KindId = kind.Id,
                GroepsreisId = groepsReis.Id,
                Opmerking = dto.Opmerking // Gebruik de opmerking uit het DTO
            };

            // Voeg Deelnemer toe aan de Deelnemer-repository
            await _context.DeelnemerRepository.AddItemAsync(deelnemer);

            // Sla wijzigingen op in de database
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Inschrijving succesvol",
                KindNaam = $"{kind.Voornaam} {kind.Naam}",
                GroepsreisNaam = groepsReis.Bestemming.Naam,
                Opmerking = dto.Opmerking
            });
        }
    }
}

