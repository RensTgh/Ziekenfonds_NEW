using System.Linq.Expressions;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public interface IOpleidingRepository : IGenericRepository<Opleiding>
    {
        Task<Opleiding> GetOpleidingWithOpleidingPersoonEnVooropleidingen(int opleidingId);

        Task<IEnumerable<Opleiding>> GetOpleidingenWithOpleidingPersoon();

        Task<IEnumerable<Opleiding>> GetOpleidingenWithOpleidingPersoonEnVooropleidingen();

        IEnumerable<OpleidingPersoon> GetRelatedOpleidingPersonen(int opleidingId);

        void RemoveOpleidingPersoon(OpleidingPersoon entity);

        Task<IEnumerable<Opleiding>> GetAllAsync(Expression<Func<Opleiding, bool>> predicate);
    }
}