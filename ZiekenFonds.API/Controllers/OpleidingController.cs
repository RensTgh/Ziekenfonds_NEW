using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZiekenFonds.API.Data.UnitOfWork;
using ZiekenFonds.API.Dto.Opleiding;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpleidingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OpleidingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<OpleidingWithPersonenDto>>> GetOpleidingen()
        {
            IEnumerable<Opleiding> opleidingen = await _unitOfWork.OpleidingRepository.GetOpleidingenWithOpleidingPersoonEnVooropleidingen();

            List<OpleidingWithPersonenDto> dto = _mapper.Map<List<OpleidingWithPersonenDto>>(opleidingen);

            return Ok(dto.ToList());
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<OpleidingWithPersonenDto>> GetOpleiding(int id)
        {
            var opleiding = await _unitOfWork.OpleidingRepository.GetOpleidingWithOpleidingPersoonEnVooropleidingen(id);

            if (opleiding == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<OpleidingWithPersonenDto>(opleiding);
            return Ok(dto);
        }

        [AllowAnonymous]
        [HttpPost("CreateOpleiding")]
        public async Task<ActionResult<OpleidingWithPersonenDto>> PostOpleiding(CreateOpleidingDto dto)
        {
            if (dto.Begindatum > dto.Einddatum)
            {
                return BadRequest("Begindatum kan niet later zijn dan Einddatum.");
            }

            var opleiding = _mapper.Map<Opleiding>(dto);

            // Zoek de bestaande opleidingen aan de hand van de opgegeven id('s)
            if (dto.VereisteOpleidingIds != null && dto.VereisteOpleidingIds.Any())
            {
                var existingOpleidingen = await _unitOfWork.OpleidingRepository
                    .GetAllAsync(o => dto.VereisteOpleidingIds.Contains(o.Id));

                if (existingOpleidingen.Count() != dto.VereisteOpleidingIds.Count)
                {
                    return BadRequest("One or more provided IDs do not exist.");
                }

                opleiding.VereisteOpleidingen = existingOpleidingen.ToList();
            }

            await _unitOfWork.OpleidingRepository.AddItemAsync(opleiding);
            await _unitOfWork.SaveChangesAsync();

            var createdOpleidingDto = _mapper.Map<OpleidingResponseDto>(opleiding);

            return CreatedAtAction("GetOpleiding", new { id = opleiding.Id }, createdOpleidingDto);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOpleiding(int id, UpdateOpleidingDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID in URL does not match ID in DTO.");
            }

            var existingOpleiding = await _unitOfWork.OpleidingRepository.GetItemAsync(id);
            if (existingOpleiding == null)
            {
                return NotFound();
            }

            // Basic Mapping
            _mapper.Map(dto, existingOpleiding);

            // Handle VereisteOpleidingIds
            if (dto.VereisteOpleidingIds != null)
            {
                // Fetch de related Opleidingen
                var vereisteOpleidingen = await _unitOfWork.OpleidingRepository
                    .GetAllAsync(o => dto.VereisteOpleidingIds.Contains(o.Id));

                if (vereisteOpleidingen.Count() != dto.VereisteOpleidingIds.Count)
                {
                    return BadRequest("One or more provided IDs do not exist.");
                }

                // Update de VereisteOpleidingen relationship
                existingOpleiding.VereisteOpleidingen = vereisteOpleidingen.ToList();
            }
            else
            {
                // Clear VereisteOpleidingen als er geen IDs zijn
                existingOpleiding.VereisteOpleidingen = new List<Opleiding>();
            }

            _unitOfWork.OpleidingRepository.UpdateItem(existingOpleiding);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await OpleidingExists(id) == false)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpleiding(int id)
        {
            var opleiding = await _unitOfWork.OpleidingRepository.GetItemAsync(id);

            if (opleiding == null)
            {
                return NotFound();
            }

            // Haal alle gerelateerde records op uit de OpleidingPersoon-tabel
            var relatedRecords = _unitOfWork.OpleidingRepository.GetRelatedOpleidingPersonen(id);

            // Verwijder alle gerelateerde records als er records gevonden worden
            if (relatedRecords.Any())
            {
                foreach (var record in relatedRecords)
                {
                    _unitOfWork.OpleidingRepository.RemoveOpleidingPersoon(record);
                }
            }

            // Verwijder de opleiding zelf
            _unitOfWork.OpleidingRepository.DeleteItem(opleiding);

            // Sla alle wijzigingen op in de database
            await _unitOfWork.SaveChangesAsync();

            // Geef een "NoContent" terug om aan te geven dat de operatie geslaagd is
            return NoContent();
        }

        private async Task<bool> OpleidingExists(int id)
        {
            var gevonden = await _unitOfWork.OpleidingRepository.GetItemAsync(id);

            if (gevonden == null)
                return false;
            else
                return true;
        }
    }
}