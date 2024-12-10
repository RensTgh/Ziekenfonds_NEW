using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public class DeelnemerRepository : GenericRepository<Deelnemer>, IDeelnemerRepository
    {
        public DeelnemerRepository(ZiekenFondsApiContext context) : base(context)
        {
        }
    }
}
