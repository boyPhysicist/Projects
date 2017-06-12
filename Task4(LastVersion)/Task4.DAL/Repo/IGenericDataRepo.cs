using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task4.DAL.Repo
{
    public interface IGenericDataRepo<T, K> : IDisposable
    {
        void Add(T obj);
        void Remove(T obj, Expression<Func<K, bool>> predicate);
        void SaveChanges();
        void Update(T obj);
        K ToEntity(T source);
        K GetEntity(T source, Expression<Func<K, bool>> predicate);
        IEnumerable<T> Items { get; }

    }
    
}
