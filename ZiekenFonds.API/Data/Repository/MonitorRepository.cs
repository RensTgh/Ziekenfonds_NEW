using Microsoft.EntityFrameworkCore;
using Monitor = ZiekenFonds.API.Models.Monitor;

namespace ZiekenFonds.API.Data.Repository

{
    public class MonitorRepository : GenericRepository<Monitor>, IMonitorRepository
    {
        public MonitorRepository(ZiekenFondsApiContext context) : base(context)
        {
        }

        public async Task<List<Monitor>> GetAllMonitorsWithName()
        {
            return await _context.Monitors.Include(x => x.Persoon).ToListAsync();
        }

        public async Task<List<Monitor>> GetMonitorDetailsAsync(string id)
        {
            return await _context.Monitors
                .Include(m => m.Groepsreis)
                .ThenInclude(m => m.Bestemming)
                .Include(m => m.Persoon.OpleidingenPersonen)
                .ThenInclude(op => op.Opleiding)
                .Where(x => x.PersoonId == id)
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var gevonden = await _context.Set<Monitor>().FindAsync(id);

            if (gevonden == null)
                return false;
            else
                return true;
        }
    }
}