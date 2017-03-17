using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Common.DAL
{
    public interface IDal<TEntity, T> where TEntity : class 
    {
        List<TEntity> GetAll();

        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        int Update(TEntity obj);

        int Insert(TEntity obj);

        int Delete(TEntity obj);

        TEntity GetById(T id);
    }
}