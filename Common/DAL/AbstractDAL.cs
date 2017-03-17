using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAL
{
    public abstract class AbstractDal<TEntity, TContext> where TEntity : class where TContext : DbContext, new()
    {
        public virtual List<TEntity> GetAll()
        {
            using (TContext entities = new TContext())
            {
                return entities.Set<TEntity>().ToList();
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using (TContext entities = new TContext())
            {
                return await entities.Set<TEntity>().ToListAsync();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            using (TContext entities = new TContext())
            {
                return entities.Set<TEntity>().Where(predicate).ToList();
            }
        }

        public TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
        {
            using (TContext entities = new TContext())
            {
                return entities.Set<TEntity>().Where(predicate).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Nombre d'objets écrit dans la base de données sous-jacente.</returns>
        public virtual int Update(TEntity obj)
        {
            return SaveOrDelete(obj, EntityState.Modified);
        }

        public virtual int Insert(TEntity obj)
        {
            return SaveOrDelete(obj, EntityState.Added);

        }

        public virtual int Insert(List<TEntity> list)
        {
            return SaveOrDelete(list, EntityState.Added);

        }

        public virtual async Task<int> InsertAsync(TEntity obj)
        {
            return await SaveOrDeleteAsync(obj, EntityState.Added);

        }

        public virtual async Task<int> InsertAsync(List<TEntity> list)
        {
            return await SaveOrDeleteAsync(list, EntityState.Added);

        }

        protected virtual int SaveOrDelete(TEntity obj, EntityState state)
        {
            using (TContext entities = new TContext())
            {
                // Update de l'objet
                entities.Entry<TEntity>(obj).State = state;

                // Execution effective des requetes
                return entities.SaveChanges();
            }
        }

        protected virtual int SaveOrDelete(List<TEntity> list, EntityState state)
        {
            using (TContext entities = new TContext())
            {
                // Update de l'objet
                entities.Set<TEntity>().AddRange(list);

                // Execution effective des requetes
                return entities.SaveChanges();
            }
        }

        protected virtual async Task<int> SaveOrDeleteAsync(TEntity obj, EntityState state)
        {
            using (TContext entities = new TContext())
            {
                // Update de l'objet
                entities.Entry<TEntity>(obj).State = state;

                // Execution effective des requetes
                return await entities.SaveChangesAsync();
            }
        }

        protected virtual async Task<int> SaveOrDeleteAsync(List<TEntity> list, EntityState state)
        {
            using (TContext entities = new TContext())
            {
                // Update de l'objet
                entities.Set<TEntity>().AddRange(list);

                // Execution effective des requetes
                return await entities.SaveChangesAsync();
            }
        }

        public virtual int Delete(TEntity obj)
        {
            return SaveOrDelete(obj, EntityState.Deleted);
        }
    }
}
