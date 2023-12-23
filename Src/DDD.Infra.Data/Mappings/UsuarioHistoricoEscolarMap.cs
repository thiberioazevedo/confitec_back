using DDD.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infra.Data.Mappings
{
    public class UsuarioHistoricoEscolarMap : IEntityTypeConfiguration<UsuarioHistoricoEscolar>
    {
        public void Configure(EntityTypeBuilder<UsuarioHistoricoEscolar> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.UsuarioId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(c => c.AnexoId)
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(c => c.Usuario).WithMany(c => c.UsuarioHistoricoEscolarCollection);

            // builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
