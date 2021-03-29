using Jorge.FrotaVeiculo.Domain.Entities;
using Jorge.FrotaVeiculo.Domain.Interfaces.Repositories;
using Jorge.FrotaVeiculo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge.FrotaVeiculo.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;
        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual T Add(T obj)
        {
            this.Validate(obj);
            return _repository.Add(obj);
        }

        public virtual T Update(T obj)
        {
            this.Validate(obj);
            return _repository.Update(obj);
        }

        public virtual void Remove(int id)
        {
            _repository.Remove(id);
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Validate(T model)
        {
            if(model == null)
            {
                throw new Exception("Nada a ser inserido / alterado");
            }
        }
    }
}
