using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZiekenFonds.API.Data.UnitOfWork;
using ZiekenFonds.API.Dto.Monitor;
using Monitor = ZiekenFonds.API.Models.Monitor;

namespace ZiekenFonds.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonitorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public MonitorController(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<Monitor>> GetAllMonitorsAsync()
        {
            IEnumerable<Monitor> monitors = await _uow.MonitorRepository.GetAllItemsAsync();

            if (monitors != null)
            { return Ok(monitors); }
            else
            { return NotFound(); }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Monitor>> GetMonitorById(int id)
        {
            Monitor monitor = await _uow.MonitorRepository.GetItemAsync(id);

            if (monitor != null)
            { return Ok(monitor); }
            else
            { return NotFound(); }
        }

        [HttpGet("MonitorsMetNaam")]
        public async Task<ActionResult<GetMonitorDto>> GetAllMonitorsWithName()
        {
            //Stap 1: Haal modellen/entiteiten op
            List<Monitor> modellen = await _uow.MonitorRepository.GetAllMonitorsWithName();

            //Stap2 omzetten automapper
            List<GetMonitorDto> result = _mapper.Map<List<GetMonitorDto>>(modellen);

            if (result != null)
            { return Ok(result); }
            else
            { return NotFound(); }
        }

        [HttpGet("MonitorDetails/{id}")]
        public async Task<ActionResult<GetMonitorDetailsDto>> GetMonitorDetails(string id)
        {
            List<Monitor> monitors = await _uow.MonitorRepository.GetMonitorDetailsAsync(id);

            if (monitors == null || !monitors.Any())
                return NotFound();

            // Gebruik Automapper om de lijst van Monitor-objecten te mappen naar de DTO
            var monitorDetailsDto = _mapper.Map<List<GetMonitorDetailsDto>>(monitors);

            // Aangezien je een lijst mapped, maar slechts één resultaat verwacht:
            return Ok(monitorDetailsDto.FirstOrDefault());
        }

        [HttpPost("CreateMonitor")]
        public async Task<ActionResult<CreateMonitorDto>> CreateMonitor(CreateMonitorDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Controleer of Groepsreis bestaat
                if (!await _uow.GroepsReisRepository.ExistsAsync(dto.GroepsreisId))
                {
                    Console.WriteLine($"Groepsreis met ID {dto.GroepsreisId} bestaat niet.");
                    return BadRequest("De opgegeven Groepsreis bestaat niet.");
                }

                // Map DTO naar Monitor-entiteit
                Monitor monitor = _mapper.Map<Monitor>(dto);

                // Voeg nieuwe Monitor toe
                await _uow.MonitorRepository.AddItemAsync(monitor);
                await _uow.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateMonitor), null);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> MonitorVerwijderen(int id)
        {
            if (_uow.MonitorRepository == null)
            {
                return NotFound();
            }

            var monitor = await _uow.MonitorRepository.GetItemAsync(id);

            if (monitor == null)
            {
                return NotFound();
            }

            _uow.MonitorRepository.DeleteItem(monitor);

            await _uow.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMonitor(int id, UpdateMonitorDto dto)
        {
            if (id != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Monitor monitor = _mapper.Map<Monitor>(dto);

            if (!await _uow.GroepsReisRepository.ExistsAsync(monitor.GroepsreisId))
            {
                return BadRequest("Deze groepsreis bestaat niet");
            }

            //TODO: Check op de toevoeging van geldige user

            _uow.MonitorRepository.UpdateItem(monitor);

            try
            {
                await _uow.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_uow.MonitorRepository.GetItemAsync(id).Result != null)
                {
                    return NotFound("Er is geen monitor gevonden met deze id");
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