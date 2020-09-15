﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AwareMD.DataLayer.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        bool Exist(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
