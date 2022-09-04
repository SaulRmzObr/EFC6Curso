namespace EFCorePeliculas.Entidades
{
    public class Genero
    {
        //Atajo, escribir: prop luego dar 2 veces tabulador para que se cree un atributo
        //[Key] Annotation para definir que sera primary key
        public int idGenero { get; set; }
        /*
         * EFCore tiene convenciones:
         * Si un campo se nombra Id, en bd se representara como Primary Key
         * Si un campo se nombra como el nombre de la clase mas id, ejemplo: GeneroId, de igual forma se representara como Primary Key
         * Sino queremos usar estas convenciones tenemos que usar anotaciones [Key] o API Fluente para definir una primary key
         */

        //Desactivar en el .csproj la opcion Nullable, dejarla en disable para que no salga en verde el atributo de tipo string

        //[StringLength(150)] Annotation para definir el tamaño de un campo string
        //[MaxLength(150)] Annotation para definir el tamaño de un campo string
        //[Required] Establece que el campo no aceptara valores nulos
        public string Nombre { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }

    }
}
