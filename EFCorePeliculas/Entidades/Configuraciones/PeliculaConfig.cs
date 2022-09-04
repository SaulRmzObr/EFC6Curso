using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PeliculaConfig : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.HasKey(prop => prop.idPelicula);
            builder.Property(prop => prop.sTitulo)
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(prop => prop.dFechaEstreno)
                .HasColumnType("date");
            builder.Property(prop => prop.sPosterUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}
