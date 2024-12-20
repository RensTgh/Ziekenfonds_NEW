using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public interface IBestemmingRepository : IGenericRepository<Bestemming>
    {
        Task<IEnumerable<Bestemming>> GetAllBestemmingen();

        Task<Bestemming?> GetBestemmingWithId(int id);
    }
}