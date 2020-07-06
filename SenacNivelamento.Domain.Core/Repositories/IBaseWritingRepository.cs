using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacNivelamento.Domain.Core.Repositories
{
    public interface IBaseWritingRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void AddRange(IEnumerable<TEntity> obj);
        void Update(TEntity obj);
        void UpdateRange(IEnumerable<TEntity> obj);
        void Remove(Guid id);
        void Remove(long id);
        //IAsyncWritingQuery<TEntity> AsAsyncQuery();
        //IAsyncWritingQuery<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken token = default);
        Task<int> SaveChangesAsync(CancellationToken token = default);
        Task<IList<TEntity>> ToListAsync(CancellationToken cancellationToken = default);
        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<long> LongCountAsync(CancellationToken cancellationToken = default);
        Task<int> CountAsync(CancellationToken cancellationToken = default);
    }
}
