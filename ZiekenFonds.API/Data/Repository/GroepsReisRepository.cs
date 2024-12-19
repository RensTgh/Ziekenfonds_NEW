using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public class GroepsReisRepository : GenericRepository<Groepsreis>, IGroepsReisRepository
    {
        public GroepsReisRepository(ZiekenFondsApiContext context) : base(context)
        {
        }

        public async Task<Groepsreis?> GetCompleteGroepsReis(int id)
        {
            return await _context.Groepsreizen
                .Include(groepsreis => groepsreis.Bestemming)
                    .ThenInclude(bestemming => bestemming.Fotos)
                .Include(groepsreis => groepsreis.Bestemming)
                    .ThenInclude(bestemming => bestemming.Reviews)
                .Include(groepsreis => groepsreis.Programmas)
                    .ThenInclude(programma => programma.Activiteit)
                .Include(groepsreis => groepsreis.Deelnemers)
                    .ThenInclude(deelnemers => deelnemers.Kind)
                    .ThenInclude(kind => kind.Persoon)
                .Include(groepsreis => groepsreis.Monitors)
                .FirstOrDefaultAsync(groepsreis => groepsreis.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var gevonden = await _context.Set<Groepsreis>().FindAsync(id);

            if (gevonden == null)
                return false;
            else
                return true;
        }

        public async Task<IEnumerable<Groepsreis>> GetCompleteGroepsReizenAsync()
        {
            return await _context.Set<Groepsreis>()
                .Include(groepsreis => groepsreis.Bestemming)
                    .ThenInclude(bestemming => bestemming.Fotos)
                .Include(groepsreis => groepsreis.Bestemming)
                    .ThenInclude(bestemming => bestemming.Reviews)
                .Include(groepsreis => groepsreis.Programmas)
                    .ThenInclude(programma => programma.Activiteit)
                .Include(groepsreis => groepsreis.Deelnemers)
                    .ThenInclude(deelnemers => deelnemers.Kind)
                .Include(groepsreis => groepsreis.Monitors)
                .ToListAsync();
        }
    }
}