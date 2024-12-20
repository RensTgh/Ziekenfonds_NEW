using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public interface IFotoRepository : IGenericRepository<Foto>
    {
        Task<IEnumerable<Foto>> GetFotosByBestemming(int bestemmingId);
    }
}