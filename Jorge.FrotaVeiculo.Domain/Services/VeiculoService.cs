using Jorge.FrotaVeiculo.Domain.Entities;
using Jorge.FrotaVeiculo.Domain.Interfaces.Repositories;
using Jorge.FrotaVeiculo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge.FrotaVeiculo.Domain.Services
{
    public class VeiculoService : BaseService<Veiculo>, IVeiculoService
    {
        private readonly IVeiculoRepository veiculoRepository;
        public VeiculoService(IVeiculoRepository veiculoRepository) : base(veiculoRepository)
        {
            this.veiculoRepository = veiculoRepository;
        }

        public override void Validate(Veiculo model)
        {
            if (model.Chassi == null) throw new Exception("Chassi é obrigatório.");
            if (model.Cor == null) throw new Exception("Cor é obrigatório.");
            if (model.ValidateNumeroPassageiros()) throw new Exception("Numero de Passageiros não corresponde ao Tipo do Veículo.");
            var veiculoWithChassi = FindByChassi(model.Chassi);
            if (veiculoWithChassi != null && (model.Id != veiculoWithChassi.Id)) throw new Exception("Já existe um veículo com esse chassi.");

        }

        public override Veiculo Add(Veiculo obj)
        {
            obj.SetNumeroPassageiros();
            return base.Add(obj);
        }

        public Veiculo Update(string chassi, string cor)
        {
            var veiculo = FindByChassi(chassi);
            if (veiculo == null) throw new Exception("Veículo não encontrado pelo chassi.");
            veiculo.Cor = cor;
            veiculo.SetNumeroPassageiros();
            return base.Update(veiculo);
        }

        public void Remove(string chassi)
        {
            var veiculo = FindByChassi(chassi);
            if (veiculo == null) throw new Exception("Chassi informado não existe");
            base.Remove(veiculo.Id);
        }

        public Veiculo FindByChassi(string chassi)
        {
            return veiculoRepository.FindByChassi(chassi);
        }
    }
}
