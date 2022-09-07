using EFCorePeliculas.Entidades;
using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.DTOs
{
    public class CineCreacionDTO
    {
        [Required]
        public string sNombre { get; set; }
        public double dLatitud { get; set; }
        public double dLongitud { get; set; }
        public CineOfertaCreacionDTO CineOferta { get; set; }
        public SalaDeCineCreacionDTO[] SalasDeCine { get; set; }
    }
}
