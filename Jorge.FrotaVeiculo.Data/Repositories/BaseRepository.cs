using Jorge.FrotaVeiculo.Data.Context;
using Jorge.FrotaVeiculo.Domain.Entities;
using Jorge.FrotaVeiculo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge.FrotaVeiculo.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected MainContext _db = new MainContext();

        public T Add(T obj)
        {
            _db.Set<T>().Add(obj);
            _db.SaveChanges();
            return obj;
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Remove(int id)
        {
            var obj = GetById(id);
            _db.Set<T>().Remove(obj);
            _db.SaveChanges();
        }

        public T Update(T obj)
        {
            _db.Set<T>().Update(obj);
            _db.SaveChanges();
            return obj;
        }
    }
}
