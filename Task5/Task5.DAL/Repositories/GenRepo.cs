using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Context;
using Task5.DAL.Interfaces;

namespace Task5.DAL.Repositories
{
    public abstract class GenRepo<T> : IRepository<T> where T : class
    {
        protected readonly OrderContext Db;

        protected GenRepo(OrderContext db)
        {
            Db = db;
        }

        public void Create(T item)
        {
            Db.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            T item = Get(id);
            if (item != null)
                Db.Set<T>().Remove(item);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return Db.Set<T>();
        }

        public void Update(T item)
        {
            Db.Entry(item).State = EntityState.Modified;
        }
    }
}
