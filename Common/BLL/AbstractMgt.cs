using Common.DAL;
using System.Collections.Generic;

namespace Common.Bll
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T">Type de l'entité</typeparam>
    /// <typeparam name="TKey">Type de la clé primaire</typeparam>
    public abstract class AbstractMgt<T, TKey> where T : class
    {
        public abstract IDal<T, TKey> Dal { get; }

        public virtual List<T> GetAll()
        {
            return Dal.GetAll();
        }

        public virtual int Update(T obj)
        {
            return Dal.Update(obj);
        }

        public virtual int Insert(T obj)
        {
            return Dal.Insert(obj);
        }

        public int Delete(T obj)
        {
            return Dal.Delete(obj);
        }

        public virtual T GetById(TKey id)
        {
            return Dal.GetById(id);
        }
    }
}