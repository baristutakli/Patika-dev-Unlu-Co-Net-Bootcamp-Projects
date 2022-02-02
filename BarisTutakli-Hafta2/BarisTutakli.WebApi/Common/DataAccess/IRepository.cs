using BarisTutakli.WebApi.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BarisTutakli.WebApi.Common.DataAccess
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
