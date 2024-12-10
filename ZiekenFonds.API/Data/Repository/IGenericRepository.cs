namespace ZiekenFonds.API.Data.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllItemsAsync();

        Task<TEntity?> GetItemAsync(int id);

        Task AddItemAsync(TEntity entity);

        void UpdateItem(TEntity entity);

        void DeleteItem(TEntity entity);

        void SaveItem();
    }
}