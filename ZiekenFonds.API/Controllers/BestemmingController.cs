using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZiekenFonds.API.Data.Repository;
using ZiekenFonds.API.Data.UnitOfWork;
using ZiekenFonds.API.Dto.Bestemming;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestemmingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BestemmingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AllBestemmingenDto>> GetBestemming(int id)
        {
            Bestemming? bestemming = await _unitOfWork.BestemmingRepository.GetBestemmingWithId(id);

            if (bestemming == null)
            {
                return NotFound($"Community {id} kan niet worden gevonden in de database");
            }

            AllBestemmingenDto dto = _mapper.Map<AllBestemmingenDto>(bestemming);

            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllBestemmingenDto>>> GetAllBestemming()
        {
            var bestemmingen = await _unitOfWork.BestemmingRepository.GetAllBestemmingen();

            List<AllBestemmingenDto> dto = _mapper.Map<List<AllBestemmingenDto>>(bestemmingen);

            return Ok(dto.ToList());
        }
    }
}
