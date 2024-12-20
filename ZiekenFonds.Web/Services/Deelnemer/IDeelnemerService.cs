using ZiekenFonds.Web.DTOS.Deelnemer;
using ZiekenFonds.Web.DTOS.Monitor;

namespace ZiekenFonds.Web.Services.Deelnemers
{
    public interface IDeelnemerService
    {
        Task<DeelnemersVanReisOphalenDTO[]> GetAllDeelnemersVanReis();
    }
}
