using Clientes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");

            builder.HasKey(c => c.IdCliente);

            builder.Property(c => c.IdCliente).HasColumnName("IDCLIENTE");

            builder.Property(c => c.Nome).HasColumnName("NOME").HasMaxLength(150).IsRequired();

            builder.Property(C => C.Cpf).HasColumnName("CPF").IsRequired();

            builder.HasIndex(c => c.Cpf).IsUnique();

            builder.Property(c => c.Telefone).HasColumnName("TELEFONE").HasMaxLength(25).IsRequired();

            builder.Property(c => c.Email).HasColumnName("EMAIL").IsRequired();

            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.DataNascimento).HasColumnName("DATANASCIMENTO").HasColumnType("date").IsRequired();

        }
    }
}
