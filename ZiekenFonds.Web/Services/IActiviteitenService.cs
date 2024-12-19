using Ziekenfonds.MVC.DTOS;
using ZiekenFonds.Web.DTOS;

namespace ZiekenFonds.Web.Services
{
    public interface IActiviteitenService
    {
        Task<ActiviteitenDTO?> GetActivityAsync(int id);
        Task<ActiviteitenDTO[]> GetAllActiviteitenAsync();

        Task CreateActiviteitAsync(CreateActiviteitDTO dto);

        Task DeleteActivityAsync(int id);

    }
}