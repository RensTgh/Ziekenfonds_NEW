using Monitor = ZiekenFonds.API.Models.Monitor;

namespace ZiekenFonds.API.Data.Repository
{
    public interface IMonitorRepository : IGenericRepository<Monitor>
    {
        Task<List<Monitor>> GetAllMonitorsWithName();

        Task<List<Monitor>> GetMonitorDetailsAsync(string id);

        Task<bool> ExistsAsync(int id);
    }
}