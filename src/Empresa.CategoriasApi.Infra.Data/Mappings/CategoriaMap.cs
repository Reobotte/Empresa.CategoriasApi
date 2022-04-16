using Empresa.CategoriasApi.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.CategoriasApi.Infra.Data.Mappings
{
    class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            // Nome da Tabela no Banco de Dados
            builder.ToTable("categoria");

            // Chave Primária
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("categoria_id")
                .HasColumnType("varchar(36)");

            builder.Property(x => x.Descricao)
                .HasColumnName("categoria")
                .HasColumnType("VarChar(80)")
                .IsRequired();

            builder.HasIndex(x => x.Descricao).IsUnique();
        }
    }
}
