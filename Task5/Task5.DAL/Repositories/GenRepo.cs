using System;
using System.Collections.Generic;
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
            T item = Db.Set<T>().Find(id);
            if (item != null)
                Db.Set<T>().Remove(item);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
