using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public class OnkostenRepository : GenericRepository<Onkosten> , IOnkostenRepository
    {
        public OnkostenRepository(ZiekenFondsApiContext context) : base(context)
        {
        }
    }
}
