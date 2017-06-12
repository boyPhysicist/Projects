using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Task4.DAL.ContextFactory;

namespace Task4.DAL.Repo
{
    public abstract class GenericDataRepo<T, TK, TContext> : IGenericDataRepo<T, TK>
        where T : class
        where TK : class
        where TContext : DbContext
    {

        protected TContext _context;
        protected GenericDataRepo(IContextFactory<TContext> factory)
        {
            _context = factory.ContObj;
        }

        public IEnumerable<T> Items
        {
            get
            {
                var b = new List<T>();
                foreach (var a in _context.Set<TK>().Select(x => x))
                {
                    b.Add(ToObject(a));
                }
                return b;
            }
        }
        public void Add(T obj)
        {
            _context.Set<TK>().Add(ToEntity(obj));
        }

        public abstract void Update(T obj);


        public TK GetEntity(T source, Expression<Func<TK, bool>> predicate)
        {
            return _context.Set<TK>().FirstOrDefault(predicate);
        }

        public void Remove(T obj, Expression<Func<TK, bool>> predicate)
        {
            var entity = _context.Set<TK>().FirstOrDefault(predicate);
            if (entity != null)
            {
                _context.Set<TK>().Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public TK ToEntity(T source)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<T, TK>());
            var entity = Mapper.Map<T, TK>(source);
            return entity;
        }
        public T ToObject(TK source)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TK, T>());
            var Object = Mapper.Map<TK, T>(source);
            return Object;
        }



        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
        ~GenericDataRepo()
        {
            if (_context != null)
            {
                Dispose();
            }
        }

    }
}
