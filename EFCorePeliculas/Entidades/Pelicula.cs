namespace EFCorePeliculas.Entidades
{
    public class Pelicula
    {
        public int idPelicula { get; set; }
        public string sTitulo { get; set; }
        public bool bSiNoCartelera { get; set; }
        public DateTime dFechaEstreno { get; set; }
        //[Unicode(false)]
        public string sPosterUrl { get; set; }
        public List<Genero> Generos { get; set; }
        public HashSet<SalaDeCine> SalasDeCine { get; set; }
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
