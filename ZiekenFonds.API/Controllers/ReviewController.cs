using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZiekenFonds.API.Data.UnitOfWork;
using ZiekenFonds.API.Dto.Activiteit;
using ZiekenFonds.API.Dto.Kind;
using ZiekenFonds.API.Dto.Monitor;
using ZiekenFonds.API.Dto.Onkosten;
using ZiekenFonds.API.Dto.Opleiding;
using ZiekenFonds.API.Dto.Review;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<OphalenReviewDto>>> GetReviews()
        {
            var reviews = await _unitOfWork.ReviewRepository.GetAllItemsAsync();

            List<OphalenReviewDto> dto = _mapper.Map<List<OphalenReviewDto>>(reviews);

            return Ok(dto.ToList());
        }

        // Add
        [HttpPost("CreateReview")]
        public async Task<ActionResult> ReviewToevoegen(CreateReviewDto dto)
        {
            // Validatie
            if (_unitOfWork.ReviewRepository == null)
                return NotFound("De tabel kind bestaat niet in de database.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Review review = _mapper.Map<Review>(dto);

            // Kind toevoegen aan de DbSet
            await _unitOfWork.ReviewRepository.AddItemAsync(review);
            try
            {
                // Kind wegschrijven naar de database
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException dbError)
            {
                return BadRequest(dbError.InnerException.Message);
            }

            return CreatedAtAction(null, null);
        }
    }
}