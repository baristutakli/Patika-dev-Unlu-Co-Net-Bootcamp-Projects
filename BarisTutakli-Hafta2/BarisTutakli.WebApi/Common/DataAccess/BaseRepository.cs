using BarisTutakli.WebApi.Common.Entities;
using BarisTutakli.WebApi.DbOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.Common.DataAccess
{
    public class BaseRepository<TEntity,TContext> : IRepository<TEntity> 
        where TEntity : BaseEntity
    
    {
        private readonly ECommerceDbContext _dbcontext;
        public BaseRepository(ECommerceDbContext context)
        {
            _dbcontext = context;
        }

        public async Task Create(TEntity entity)
        {
            await _dbcontext.Set<TEntity>().AddAsync(entity);
              await _dbcontext.SaveChangesAsync();
        }

        public  Task Delete(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Remove(entity);
            return  _dbcontext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await  _dbcontext.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return  filter == null ?  _dbcontext.Set<TEntity>().AsNoTracking() :
                _dbcontext.Set<TEntity>().Where(filter).AsNoTracking();
        }

        public Task Update(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Update(entity);
            return _dbcontext.SaveChangesAsync();
        }

    
    }
}
