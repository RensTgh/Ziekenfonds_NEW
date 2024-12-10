using System.Linq.Expressions;
using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public interface IGroepsReisRepository : IGenericRepository<Groepsreis>
    {
        Task<Groepsreis?> GetCompleteGroepsReis(int id);

        Task<IEnumerable<Groepsreis>> GetCompleteGroepsReizenAsync();

        Task<bool> ExistsAsync(int id);
    }
}