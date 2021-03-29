using Jorge.FrotaVeiculo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jorge.FrotaVeiculo.Data.Mapping
{
    public class VeiculoMap : BaseMap<Veiculo>
    {
        public override void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.Property(v => v.Chassi).IsRequired();
            builder.HasIndex(v => v.Chassi).IsUnique();
        }
    }
}
