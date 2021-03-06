﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Task4.DM.Entities;

namespace Task4.DAL.Repo.Interfaces
{
    public interface IGenericDataRepository<T, K> : IDisposable
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
