using Microsoft.EntityFrameworkCore;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public class BestemmingRepository : GenericRepository<Bestemming>, IBestemmingRepository
    {
        public BestemmingRepository(ZiekenFondsApiContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Bestemming>> GetAllBestemmingen()
        {
            return await _context.Set<Bestemming>()
                .Include(bestemming => bestemming.Reviews)
                .Include(bestemming => bestemming.Fotos)
                .Include(bestemming => bestemming.Groepsreizen)
                .ToListAsync();
        }

        public async Task<Bestemming?> GetBestemmingWithId(int id)
        {
            return await _context.Set<Bestemming>()
                            .Include(bestemming => bestemming.Reviews)
                            .Include(bestemming => bestemming.Fotos)
                            .Include(bestemming => bestemming.Groepsreizen)
                            .FirstOrDefaultAsync(bestemming => bestemming.Id == id);
        }
    }
}
