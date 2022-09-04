namespace EFCorePeliculas.Entidades
{
    public class CineOferta
    {
        public int idCineOferta { get; set; }
        public DateTime dFechaInicio { get; set; }
        public DateTime dFechaFin { get; set; }
        public decimal dPorcentajeDescuento { get; set; }
        public int CineId { get; set; }
    }
}
