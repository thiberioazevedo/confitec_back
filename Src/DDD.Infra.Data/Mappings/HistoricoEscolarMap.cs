using DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infra.Data.Mappings
{
    public class HistoricoEscolarMap : IEntityTypeConfiguration<Anexo>
    {
        public void Configure(EntityTypeBuilder<Anexo> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Formato)
                .HasColumnType("varchar(4)")
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(c => c.Arquivo)
                .HasColumnType("varbinary(max)")
                .IsRequired();

            // builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.HasQueryFilter(p => !p.IsDeleted);
            builder.HasMany(c => c.UsuarioHistoricoEscolarCollection).WithOne(c => c.Anexo);
        }
    }
}
