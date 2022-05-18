using Microsoft.EntityFrameworkCore;
using Karizma.Sample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Karizma.Sample.Persistance.Extensions;

namespace Karizma.Sample.Persistance.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _context;

        public GenericRepository(RepositoryDbContext context)
        {
            _context = context.Set<T>();
        }

        public async Task Create(T model)
        {
            await _context.AddAsync(model);
        }

        public async Task<T> Update(T model)
        {
            _context.Update(model);

            return model;
        }

        public async Task Delete(Expression<Func<T, bool>> query, params string[] includes)
        {
            var model = await _context.ApplyIncludes<T>(includes).FirstOrDefaultAsync(query);

            _context.Remove(model);
        }

        public async Task DeleteRange(Expression<Func<T, bool>> query, params string[] includes)
        {
            var models = await _context.ApplyIncludes<T>(includes).Where(query).ToListAsync();

            foreach (var model in models)
                _context.Remove(model);
        }

        public async Task<T> Get(Expression<Func<T, bool>> query, params string[] includes)
        {
            return await _context.ApplyIncludes<T>(includes).FirstOrDefaultAsync(query);
        }

        public async Task<IList<T>> GetAllAccending(Expression<Func<T, bool>> query, Expression<Func<T, object>> keySelector, params string[] includes)
        {
            return await _context.ApplyIncludes<T>(includes).Where(query).OrderBy(keySelector).ToListAsync();
        }

        public async Task<IList<T>> GetAllDescending(Expression<Func<T, bool>> query, Expression<Func<T, object>> keySelector, params string[] includes)
        {
            return await _context.ApplyIncludes<T>(includes).Where(query).OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<(IList<T>, int)> GetAllWithPaginationAccending(Expression<Func<T, bool>> query, Expression<Func<T, object>> keySelector, int pageSize, int page, params string[] includes)
        {
            var models = _context.ApplyIncludes<T>(includes)
                .Where(query)
                .OrderBy(keySelector);

            return new(await models.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(), await models.CountAsync());
        }

        public async Task<(IList<T>, int)> GetAllWithPaginationDescending(Expression<Func<T, bool>> query, Expression<Func<T, object>> keySelector, int pageSize, int page, params string[] includes)
        {
            var models = _context.ApplyIncludes<T>(includes)
                .Where(query)
                .OrderByDescending(keySelector);

            return new(await models.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(), await models.CountAsync());
        }

        public async Task<int> Count(Expression<Func<T, bool>> query)
        {
            return await _context.CountAsync(query);
        }

        public async Task<decimal> Sum(Expression<Func<T, bool>> query, Expression<Func<T, decimal>> keySelector, params string[] includes)
        {
            return await _context.ApplyIncludes(includes).Where(query).SumAsync(keySelector);
        }
    }
}
