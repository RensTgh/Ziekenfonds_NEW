using ZiekenFonds.Web.DTOS.Deelnemer;

namespace ZiekenFonds.Web.Services.Deelnemers
{
    public interface IDeelnemerService
    {
        Task<DeelnemersVanReisOphalenDTO[]> GetAllDeelnemersVanReis();
    }
}