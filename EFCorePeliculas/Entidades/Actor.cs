namespace EFCorePeliculas.Entidades
{
    public class Actor
    {
        public int idActor { get; set; }
        private string _sNombre;
        public string sNombre 
        {
            get { return _sNombre; }
            set
            {
                _sNombre = String.Join(' ', 
                    value.Split(' ')
                    .Select(letra => 
                    string.Format("{0}{1}", 
                    letra[0].ToString().ToUpper(), 
                    letra.Substring(1).ToLower())).ToArray());
            }
        }
        public string sBiografia { get; set; }
        //[Column(TypeName ="Date")]
        public DateTime? dFechaNacimiento { get; set; }
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
