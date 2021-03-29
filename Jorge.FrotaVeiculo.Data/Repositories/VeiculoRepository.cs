using Jorge.FrotaVeiculo.Domain.Entities;
using Jorge.FrotaVeiculo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jorge.FrotaVeiculo.Data.Repositories
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        

        public Veiculo FindByChassi(string chassi)
        {
            return _db.Veiculo.FirstOrDefault(x=>x.Chassi.ToUpper() == chassi.ToUpper());
        }
    }
}
