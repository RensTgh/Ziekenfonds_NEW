using Ziekenfonds.MVC.DTOS;

namespace ZiekenFonds.Web.Services
{
    public interface IActiviteitenService
    {
        Task<ActiveitenDTO?> GetActivityAsync(int id);
        Task<ActiveitenDTO[]> GetAllActiviteitenAsync();
    }
}