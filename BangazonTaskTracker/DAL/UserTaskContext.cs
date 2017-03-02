using BangazonTaskTracker.Models;
using System.Data.Entity;

namespace BangazonTaskTracker.DAL
{
    public class UserTaskContext: DbContext
    {
        public virtual DbSet<UserTask> UserTasks { get; set; }

        public DbSet<TEntity> GetCollection<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }
    }
}