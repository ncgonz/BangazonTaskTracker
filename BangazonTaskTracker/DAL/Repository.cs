using System.Data.Entity;
using System.Linq;

namespace BangazonTaskTracker.DAL
{
    public class Repository : IRepository
    {
        readonly UserTaskContext _context;

        public Repository()
        {
            _context = new UserTaskContext();
        }

        public Repository(UserTaskContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IDbModel
        {
            return _context.GetCollection<TEntity>().AsQueryable();
        }

        public TEntity GetById<TEntity>(int id) where TEntity : class, IDbModel
        {
            return _context.GetCollection<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public void Insert<TEntity>(TEntity itemToInsert) where TEntity : class, IDbModel
        {
            _context.GetCollection<TEntity>().Add(itemToInsert);
        }

        public void Delete<TEntity>(int id) where TEntity : class, IDbModel
        {
            _context.GetCollection<TEntity>().Remove(GetById<TEntity>(id));
        }

        public void Upsert<TEntity>(TEntity objectToSave) where TEntity : class, IDbModel
        {
            var exist = _context.GetCollection<TEntity>().Any(t => t.Id == objectToSave.Id);
            if (exist)
            {
                _context.GetCollection<TEntity>().Attach(objectToSave);
                _context.Entry(objectToSave).State = EntityState.Modified;
            }
            else
            {
                _context.GetCollection<TEntity>().Add(objectToSave);
            }

            _context.SaveChanges();
        }
    }
}