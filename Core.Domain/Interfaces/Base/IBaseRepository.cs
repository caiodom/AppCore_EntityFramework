﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces
{
    public interface IBaseRepository<T> where T:BaseEntity,new ()
    {
        Task<IEnumerable<T>> GetAsync(bool asNoTracking = true);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true);


        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderBy, bool asNoTracking = true);

        Task<T> GetByIdAsync(int entityId, bool asNoTracking = true);

        Task AddAsync(T entity);


        Task AddCollectionAsync(IEnumerable<T> entities);


        IEnumerable<T> AddCollectionWithProxy(IEnumerable<T> entities);



        Task UpdateAsync(T entity);


        Task UpdateCollectionAsync(IEnumerable<T> entities);


        IEnumerable<T> UpdateCollectionWithProxy(IEnumerable<T> entities);


        Task RemoveByAsync(Func<T, bool> where);


        Task RemoveAsync(T entity);


        Task SaveChangesAsync();



        IEnumerable<T> Get(bool asNoTracking = true);


        IEnumerable<T> Get(Expression<Func<T, bool>> expression, bool asNoTracking = true);


        IEnumerable<T> Get(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderBy, bool asNoTracking = true);

        IQueryable<T> Get(Expression<Func<T, bool>> expression = null,
                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                         int? take = null,
                                         int? skip = null,
                                         bool asNoTracking = true,
                                         params Expression<Func<T, object>>[] includes);

        IQueryable<T> GetWithIncludes(bool asNoTracking = true, params Expression<Func<T, object>>[] includeProperties);


        T GetById(int entityId, bool asNoTracking = true);
    }
}
