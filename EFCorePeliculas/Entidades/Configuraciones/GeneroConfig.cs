using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.HasKey(prop => prop.idGenero); //para definir la primary key de nuestra tabla
            builder.Property(prop => prop.Nombre)
                //.HasColumnName("sNombre") //definir el nombre de una columna de una tabla
                .HasMaxLength(150) //Definir el tamaño de un campo string,
                .IsRequired(); //Definir que el campo no acepte valores nulos
            //modelBuilder.Entity<Genero>().ToTable(name: "Genero", schema: "peliculas"); //Definir el nombre de una tabla y su nombre de su esquema
        }
    }
}
