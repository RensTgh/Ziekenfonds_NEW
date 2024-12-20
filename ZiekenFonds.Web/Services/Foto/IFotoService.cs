using ZiekenFonds.Web.DTOS.Foto;

namespace ZiekenFonds.Web.Services
{
    public interface IFotoService
    {
        Task<GetFotoDto[]> GetAllFotosAsync(int bestemmingId);

        Task UploadFotoAsync(UploadFotoDto dto);

        Task DeleteFotoAsync(int id);
    }
}