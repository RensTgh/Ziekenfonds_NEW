using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ZiekenFondsApiContext context) : base(context)
        {
        }
    }
}