using Microsoft.EntityFrameworkCore;

namespace ZiekenFonds.API.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ZiekenFondsApiContext _context;

        public GenericRepository(ZiekenFondsApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllItemsAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetItemAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task AddItemAsync(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteItem(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void UpdateItem(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void SaveItem()
        {
            _context.SaveChangesAsync();
        }
    }
}