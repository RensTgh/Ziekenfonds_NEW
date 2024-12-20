namespace ZiekenFonds.Web.Services.Bestemming
{
    public interface IBestemmingService
    {
        Task<Models.Bestemming[]> GetAllBestemmingenAsync();
    }
}