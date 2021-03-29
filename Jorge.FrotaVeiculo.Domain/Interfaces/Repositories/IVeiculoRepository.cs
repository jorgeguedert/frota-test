using Jorge.FrotaVeiculo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge.FrotaVeiculo.Domain.Interfaces.Repositories
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        Veiculo FindByChassi(string chassi);
    }
}
