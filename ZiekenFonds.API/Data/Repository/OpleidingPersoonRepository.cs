using ZiekenFonds.API.Models;

namespace ZiekenFonds.API.Data.Repository
{
    public class OpleidingPersoonRepository : GenericRepository<OpleidingPersoon>, IOpleidingPersoonRepository
    {
        public OpleidingPersoonRepository(ZiekenFondsApiContext context) : base(context)
        {
        }
    }
}
