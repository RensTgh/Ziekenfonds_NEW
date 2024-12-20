using ZiekenFonds.Web.DTOS.Review;

namespace ZiekenFonds.Web.Services.Review
{
    public interface IReviewServices
    {
        Task CreateReviewAsync(CreateReviewPageDto dto);
        Task<ReviewOphalenPageDto[]> GetAllReviewsAsync();
    }
}