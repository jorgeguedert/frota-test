using Jorge.FrotaVeiculo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge.FrotaVeiculo.Domain.Interfaces.Services
{
    public interface IVeiculoService : IBaseService<Veiculo>
    {
        Veiculo Update(string chassi, string cor);

        void Remove(string chassi);
        Veiculo FindByChassi(string chassi);
    }
}
