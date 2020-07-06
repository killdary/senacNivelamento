using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacNivelamento.Infra.Writing.Data.Repositories
{
    public class BaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        protected readonly WritingContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(WritingContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Add(TEntity obj) => _dbSet.Add(obj);

        public void AddRange(IEnumerable<TEntity> obj) => _dbSet.AddRange(obj);

        public async Task<TEntity> GetByIdAsync(
            Guid id,
            CancellationToken token = default)
        {
            return await _dbSet.FindAsync(new[] { (object)id }, token);
        }

        public virtual void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> obj)
        {
            _dbSet.UpdateRange(obj);
        }

        public virtual void Remove(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public virtual void Remove(long id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            return _context.SaveChangesAsync(token);
        }


        public async Task<IList<TEntity>> ToListAsync(
            CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync();
        }

        public Task<TEntity> FirstAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return _dbSet.FirstAsync(predicate, cancellationToken);
        }

        public Task<TEntity> SingleAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return _dbSet.SingleAsync(predicate, cancellationToken);
        }

        public Task<TEntity> FirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public Task<TEntity> SingleOrDefaultAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return _dbSet.SingleOrDefaultAsync(predicate, cancellationToken);
        }

        public Task<long> LongCountAsync(
            CancellationToken cancellationToken = default)
        {
            return _dbSet.LongCountAsync(cancellationToken);
        }

        public Task<int> CountAsync(
            CancellationToken cancellationToken = default)
        {
            return _dbSet.CountAsync(cancellationToken);
        }
    }
}
