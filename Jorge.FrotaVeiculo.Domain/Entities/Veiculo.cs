using Jorge.FrotaVeiculo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge.FrotaVeiculo.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public string Chassi { get; set; }
        public ETipoVeiculo Tipo { get; set; }
        public int NumeroPassageiros { get; set; }
        public string Cor { get; set; }

        public void SetNumeroPassageiros()
        {
            if (this.Tipo == ETipoVeiculo.Caminhao) this.NumeroPassageiros = 2;
            else this.NumeroPassageiros = 42;
    }

        public void SetTipo(ETipoVeiculo tipo)
        {
            this.Tipo = tipo;
            this.SetNumeroPassageiros();
        }

        public bool ValidateNumeroPassageiros()
        {
            if ((this.NumeroPassageiros != 2 && this.Tipo == ETipoVeiculo.Caminhao)
                || (NumeroPassageiros != 42 && this.Tipo == ETipoVeiculo.Onibus)) return true;
            else return false;
        }
    }

   
}
