using System.Reflection.Metadata.Ecma335;

namespace EFCorePeliculas.DTOs
{
    public class CineDTO
    {
        public int idCine { get; set; }
        public string sNombre { get; set; }
        public double dLatitud { get; set; }
        public double dLongitud { get; set; }
    }
}
