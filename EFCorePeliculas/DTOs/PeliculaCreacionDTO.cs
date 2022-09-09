using EFCorePeliculas.Entidades;

namespace EFCorePeliculas.DTOs
{
    public class PeliculaCreacionDTO
    {
        public string sTitulo { get; set; }
        public bool bSiNoCartelera { get; set; }
        public DateTime dFechaEstreno { get; set; }
        public List<int> Generos { get; set; }
        public List<int> SalasDeCine { get; set; }
        public List<PeliculaActorCreacionDTO> PeliculasActores { get; set; }
    }
}
