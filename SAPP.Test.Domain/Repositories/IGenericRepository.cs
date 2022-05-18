using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Karizma.Sample.Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<int> Count(Expression<Func<T, bool>> query);
    Task Create(T model);
    Task Delete(Expression<Func<T, bool>> query, params string[] includes);
    Task DeleteRange(Expression<Func<T, bool>> query, params string[] includes);
    Task<T> Get(Expression<Func<T, bool>> query, params string[] includes);
    Task<IList<T>> GetAllAccending(Expression<Func<T, bool>> query, Expression<Func<T, object>> keySelector, params string[] includes);
    Task<IList<T>> GetAllDescending(Expression<Func<T, bool>> query, Expression<Func<T, object>> keySelector, params string[] includes);
    Task<(IList<T>, int)> GetAllWithPaginationAccending(Expression<Func<T, bool>> query, Expression<Func<T, object>> keySelector, int pageSize, int page, params string[] includes);
    Task<(IList<T>, int)> GetAllWithPaginationDescending(Expression<Func<T, bool>> query, Expression<Func<T, object>> keySelector, int pageSize, int page, params string[] includes);
    Task<decimal> Sum(Expression<Func<T, bool>> query, Expression<Func<T, decimal>> keySelector, params string[] includes);
    Task<T> Update(T model);
}

