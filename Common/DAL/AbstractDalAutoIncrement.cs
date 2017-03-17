using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.DAL;

namespace Common.DAL
{
    public abstract class AbstractDalAutoIncrement<TEntity, TContext> :  
        AbstractDal<TEntity, TContext>, IDal<TEntity, int> where TEntity : Entite where TContext : DbContext, new()  
    {
        public virtual TEntity GetById(int id)
        {
            return GetAll(o => o.Id == id).FirstOrDefault();
        }
    }
}
