namespace EFCorePeliculas.Entidades
{
    public class SalaDeCine
    {
        public int idSalaCine { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
        public decimal dPrecio { get; set; }
        public int CineId { get; set; }
        public Cine Cine { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}
