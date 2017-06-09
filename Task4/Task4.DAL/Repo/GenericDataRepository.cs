using Task4.DM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Task4.DAL.Repo
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        public void Add(params T[] items)
        {
            using (var context = new SalesDBEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Added;
                }
                context.SaveChanges();
            }
        }

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new SalesDBEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));

                list = dbQuery
                    .AsNoTracking()
                    .ToList();
            }
            return list;
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new SalesDBEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList();
            }
            return list;
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item;
            using (var context = new SalesDBEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                dbQuery = navigationProperties
                    .Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));

                item = dbQuery
                    .AsNoTracking()
                    .FirstOrDefault(where); 
            }
            return item;
        }

        public void Remove(params T[] items)
        {
            using (var context = new SalesDBEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }

        public void Update(params T[] items)
        {
            using (var context = new SalesDBEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();
            }
        }
    }
}
