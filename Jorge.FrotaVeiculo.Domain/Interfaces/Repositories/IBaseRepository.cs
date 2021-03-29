using Jorge.FrotaVeiculo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge.FrotaVeiculo.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Add(T obj);
        T Update(T obj);
        void Remove(int id);

        T GetById(int id);
        IEnumerable<T> GetAll();

    }
}
