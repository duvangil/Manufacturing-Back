using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Infrastructure.Configurations
{
    public interface IQueryableUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
        void DetachLocal<TEntity>(TEntity entity, EntityState state) where TEntity : class;
        DbContext GetContext();
        DbSet<TEntity> GetSet<TEntity>() where TEntity : class;
    }
}
