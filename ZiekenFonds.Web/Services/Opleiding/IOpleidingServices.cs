using ZiekenFonds.Web.DTOS.Opleiding;

namespace ZiekenFonds.Web.Services.Opleiding
{
    public interface IOpleidingServices
    {
        Task<OpleidingOphalenDto[]> GetAllOpleidingenAsync();

        Task CreateOpleidingAsync(CreateOpleidingPageDto dto);

        Task DeleteOpleiding(int id);

        Task<OpleidingMonitorPageDto[]> GetAllMonitorsAsync();

        Task InschrijvenAsync(OpleidingPersoonInschrijvingDto inschrijving);
    }
}