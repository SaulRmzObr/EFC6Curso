using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Entidades
{
    public class Cine
    {
        public int idCine { get; set; }
        public string sNombre { get; set; }
        //[Precision(precision: 9, scale: 2)]
        public Point Ubicacion { get; set; }
        public CineOferta CineOferta { get; set; }
        public HashSet<SalaDeCine> SalasDeCine { get; set; }
        /* Otras alternativas de HashSet:
         * public ICollection<SalaDeCine> SalasDeCine { get; set; }
         * public List<SalaDeCine> SalasDeCine { get; set; }
         */
    }
}
