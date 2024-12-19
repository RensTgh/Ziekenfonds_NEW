using Microsoft.EntityFrameworkCore;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public class FotoRepository : GenericRepository<Foto>, IFotoRepository
    {
        public FotoRepository(ZiekenFondsApiContext context) : base(context) { }
        
        public async Task<IEnumerable<Foto>> GetFotosByBestemming(int bestemmingId)
        {
            return await _context.Fotos.Where(f => f.BestemmingId == bestemmingId).ToListAsync();
        }   
    }
}
