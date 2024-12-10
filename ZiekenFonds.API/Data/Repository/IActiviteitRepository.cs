using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public interface IActiviteitRepository : IGenericRepository<Activiteit>
    {
        Task VoegActiviteitenToeAanReis(int groepsReisId, int[] activiteitId);

        Task VerwijderActiviteitenVanReis(int groepsreisId);
    }
}