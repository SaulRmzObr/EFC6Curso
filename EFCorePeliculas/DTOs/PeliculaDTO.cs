namespace EFCorePeliculas.DTOs
{
    public class PeliculaDTO
    {
        public int idPelicula { get; set; }
        public string sTitulo { get; set; }
        public ICollection<GeneroDTO> Generos { get; set; } = new List<GeneroDTO>();
        public ICollection<CineDTO> Cines { get; set; }
        public ICollection<ActorDTO> Actores { get; set; }
    }
}
