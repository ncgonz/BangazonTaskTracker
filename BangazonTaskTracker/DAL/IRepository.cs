using System.Linq;

namespace BangazonTaskTracker.DAL
{
    public interface IRepository
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IDbModel;
        TEntity GetById<TEntity>(int id) where TEntity : class, IDbModel;
        void Insert<TEntity>(TEntity itemToInsert) where TEntity : class, IDbModel;
        void Delete<TEntity>(int id) where TEntity : class, IDbModel;
        void Upsert<TEntity>(TEntity objectToSave) where TEntity : class, IDbModel;
    }
}