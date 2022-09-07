using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.DTOs
{
    public class CineOfertaCreacionDTO
    {
        public DateTime dFechaInicio { get; set; }
        public DateTime dFechaFin { get; set; }
        [Range(1,100)]
        public decimal dPorcentajeDescuento { get; set; }
    }
}
