namespace EFCorePeliculas.Entidades
{
    public class Actor
    {
        public int idActor { get; set; }
        public string sNombre { get; set; }
        public string sBiografia { get; set; }
        //[Column(TypeName ="Date")]
        public DateTime? dFechaNacimiento { get; set; }
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
