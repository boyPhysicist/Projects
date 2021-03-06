﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Task4.DAL.Repo.Interfaces;
using Task4.DAL.ContextFactory;
using EntityState = System.Data.Entity.EntityState;

namespace Task4.DAL.Repo
{
    public abstract class GenericDataRepository<T, K, Context> : IGenericDataRepository<T, K> 
        where T : class 
        where K : class 
        where Context : DbContext
    {

        protected Context _context;
        protected GenericDataRepository(IContextFactory<Context> factory)
        {
            _context = factory.ContObj;
        }

        public IEnumerable<T> Items
        {
            get
            {
                var b = new List<T>();
                foreach (var a in _context.Set<K>().Select(x => x))
                {
                    b.Add(ToObject(a));
                }
                return b;
            }
        }
        public void Add(T obj)
        {
            _context.Set<K>().Add(ToEntity(obj));
        }

        public abstract void Update(T obj);
        

        public K GetEntity(T source, Expression<Func<K, bool>> predicate)
        {
            return _context.Set<K>().FirstOrDefault(predicate);
        }

        public void Remove(T obj, Expression<Func<K, bool>> predicate)
        {
            var entity = _context.Set<K>().FirstOrDefault(predicate);
            if (entity != null)
            {
                _context.Set<K>().Remove(entity);
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

        public K ToEntity(T source)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<T, K>());
            var entity = Mapper.Map<T, K>(source);
            return entity;
        }
        public T ToObject(K source)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<K, T>());
            var Object = Mapper.Map<K, T>(source);
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
        ~GenericDataRepository()
        {
            if (_context != null)
            {
                Dispose();
            }
        }

    }
}
