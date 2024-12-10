using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public class ActiviteitRepository : GenericRepository<Activiteit>, IActiviteitRepository
    {
        public ActiviteitRepository(ZiekenFondsApiContext context) : base(context)
        {
        }

        public async Task VoegActiviteitenToeAanReis(int groepsReisId, int[] activiteitId)
        {
            List<Programma> programmas = new List<Programma>();

            for (int i = 0; i < activiteitId.Length; i++)
            {
                programmas.Add(new Programma
                {
                    GroepsreisId = groepsReisId,
                    ActiviteitId = activiteitId[i],
                });
            }

            await _context.Programmas.AddRangeAsync(programmas);
        }

        public async Task VerwijderActiviteitenVanReis(int groepsreisId)
        {
            var programmas = _context.Programmas.Where(a => a.GroepsreisId == groepsreisId);
            _context.Programmas.RemoveRange(programmas);
            await _context.SaveChangesAsync();
        }
    }
}