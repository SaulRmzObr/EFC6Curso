namespace EFCorePeliculas.DTOs
{
    public class PeliculasFiltroDTO
    {
        public string Titulo { get; set; }
        public int IdGenero { get; set; }
        public bool EnCartelera { get; set; }
        public bool ProximosEstrenos { get; set; }
    }
}
