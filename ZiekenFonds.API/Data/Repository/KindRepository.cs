using Microsoft.EntityFrameworkCore;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public class KindRepository : GenericRepository<Kind>, IKindRepository
    {
        public KindRepository(ZiekenFondsApiContext context) : base(context)
        {
            
        }

        public new async Task<Kind> GetItemAsync(int id)
        {
            return await _context.Kinderen
                .Include(k => k.Persoon) // Ensure Persoon is loaded
                .FirstOrDefaultAsync(k => k.Id == id);
        }

        public new async Task<IEnumerable<Kind>> GetAllItemsAsync()
        {
            return await _context.Kinderen
                .Include(k => k.Persoon) // Ensure Persoon is loaded
                .ToListAsync();
        }
    }
}
