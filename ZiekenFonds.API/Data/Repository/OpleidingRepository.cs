using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public class OpleidingRepository : GenericRepository<Opleiding>, IOpleidingRepository
    {
        public OpleidingRepository(ZiekenFondsApiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Opleiding>> GetOpleidingenWithOpleidingPersoon()
        {
            return await _context.Set<Opleiding>().Include(opleiding => opleiding.OpleidingenPersonen).ThenInclude(opleidingPersoon => opleidingPersoon.Persoon).ToListAsync();
        }

        public async Task<IEnumerable<Opleiding>> GetOpleidingenWithOpleidingPersoonEnVooropleidingen()
        {
            return await _context.Set<Opleiding>()
                .Include(opleiding => opleiding.OpleidingenPersonen)
                .ThenInclude(opleidingPersoon => opleidingPersoon.Persoon)
                .Include(opleiding => opleiding.VereisteOpleidingen)
                .ToListAsync();
        }

        public IEnumerable<OpleidingPersoon> GetRelatedOpleidingPersonen(int opleidingId)
        {
            return _context.OpleidingPersonen.Where(op => op.OpleidingId == opleidingId);
        }

        public void RemoveOpleidingPersoon(OpleidingPersoon entity)
        {
            _context.OpleidingPersonen.Remove(entity);
        }

        public async Task<IEnumerable<Opleiding>> GetAllAsync(Expression<Func<Opleiding, bool>> predicate)
        {
            return await _context.Opleidingen.Where(predicate).ToListAsync();
        }

        public async Task<Opleiding> GetOpleidingWithOpleidingPersoonEnVooropleidingen(int opleidingId)
        {
            return await _context.Set<Opleiding>()
                .Include(opleiding => opleiding.OpleidingenPersonen)
                .ThenInclude(opleidingPersoon => opleidingPersoon.Persoon)
                .Include(opleiding => opleiding.VereisteOpleidingen)
                .FirstOrDefaultAsync(op => op.Id == opleidingId);
        }
    }
}