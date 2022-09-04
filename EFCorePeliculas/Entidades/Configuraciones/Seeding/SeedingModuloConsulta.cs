using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NetTopologySuite;

namespace EFCorePeliculas.Entidades.Configuraciones.Seeding
{
    public class SeedingModuloConsulta
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var acción = new Genero { idGenero = 1, Nombre = "Acción" };
            var animación = new Genero { idGenero = 2, Nombre = "Animación" };
            var comedia = new Genero { idGenero = 3, Nombre = "Comedia" };
            var cienciaFicción = new Genero { idGenero = 4, Nombre = "Ciencia ficción" };
            var drama = new Genero { idGenero = 5, Nombre = "Drama" };

            modelBuilder.Entity<Genero>().HasData(acción, animación, comedia, cienciaFicción, drama);

            var tomHolland = new Actor() { idActor = 1, sNombre = "Tom Holland", dFechaNacimiento = new DateTime(1996, 6, 1), sBiografia = "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico." };
            var samuelJackson = new Actor() { idActor = 2, sNombre = "Samuel L. Jackson", dFechaNacimiento = new DateTime(1948, 12, 21), sBiografia = "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto." };
            var robertDowney = new Actor() { idActor = 3, sNombre = "Robert Downey Jr.", dFechaNacimiento = new DateTime(1965, 4, 4), sBiografia = "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York." };
            var chrisEvans = new Actor() { idActor = 4, sNombre = "Chris Evans", dFechaNacimiento = new DateTime(1981, 06, 13) };
            var laRoca = new Actor() { idActor = 5, sNombre = "Dwayne Johnson", dFechaNacimiento = new DateTime(1972, 5, 2) };
            var auliCravalho = new Actor() { idActor = 6, sNombre = "Auli'i Cravalho", dFechaNacimiento = new DateTime(2000, 11, 22) };
            var scarlettJohansson = new Actor() { idActor = 7, sNombre = "Scarlett Johansson", dFechaNacimiento = new DateTime(1984, 11, 22) };
            var keanuReeves = new Actor() { idActor = 8, sNombre = "Keanu Reeves", dFechaNacimiento = new DateTime(1964, 9, 2) };

            modelBuilder.Entity<Actor>().HasData(tomHolland, samuelJackson,
                            robertDowney, chrisEvans, laRoca, auliCravalho, scarlettJohansson, keanuReeves);
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var agora = new Cine() { idCine = 1, sNombre = "Agora Mall", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233)) };
            var sambil = new Cine() { idCine = 2, sNombre = "Sambil", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.911582, 18.482455)) };
            var megacentro = new Cine() { idCine = 3, sNombre = "Megacentro", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.856309, 18.506662)) };
            var acropolis = new Cine() { idCine = 4, sNombre = "Acropolis", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.939248, 18.469649)) };

            var agoraCineOferta = new CineOferta { idCineOferta = 1, CineId = agora.idCine, dFechaInicio = DateTime.Today, dFechaFin = DateTime.Today.AddDays(7), dPorcentajeDescuento = 10 };

            var salaDeCine2DAgora = new SalaDeCine()
            {
                idSalaCine = 1,
                CineId = agora.idCine,
                dPrecio = 220,
                TipoSalaDeCine = TipoSalaDeCine.DosDimensiones
            };
            var salaDeCine3DAgora = new SalaDeCine()
            {
                idSalaCine = 2,
                CineId = agora.idCine,
                dPrecio = 320,
                TipoSalaDeCine = TipoSalaDeCine.TresDimensiones
            };

            var salaDeCine2DSambil = new SalaDeCine()
            {
                idSalaCine = 3,
                CineId = sambil.idCine,
                dPrecio = 200,
                TipoSalaDeCine = TipoSalaDeCine.DosDimensiones
            };
            var salaDeCine3DSambil = new SalaDeCine()
            {
                idSalaCine = 4,
                CineId = sambil.idCine,
                dPrecio = 290,
                TipoSalaDeCine = TipoSalaDeCine.TresDimensiones
            };


            var salaDeCine2DMegacentro = new SalaDeCine()
            {
                idSalaCine = 5,
                CineId = megacentro.idCine,
                dPrecio = 250,
                TipoSalaDeCine = TipoSalaDeCine.DosDimensiones
            };
            var salaDeCine3DMegacentro = new SalaDeCine()
            {
                idSalaCine = 6,
                CineId = megacentro.idCine,
                dPrecio = 330,
                TipoSalaDeCine = TipoSalaDeCine.TresDimensiones
            };
            var salaDeCineCXCMegacentro = new SalaDeCine()
            {
                idSalaCine = 7,
                CineId = megacentro.idCine,
                dPrecio = 450,
                TipoSalaDeCine = TipoSalaDeCine.CXC
            };

            var salaDeCine2DAcropolis = new SalaDeCine()
            {
                idSalaCine = 8,
                CineId = acropolis.idCine,
                dPrecio = 250,
                TipoSalaDeCine = TipoSalaDeCine.DosDimensiones
            };

            var acropolisCineOferta = new CineOferta { idCineOferta = 2, CineId = acropolis.idCine, dFechaInicio = DateTime.Today, dFechaFin = DateTime.Today.AddDays(5), dPorcentajeDescuento = 15 };

            modelBuilder.Entity<Cine>().HasData(acropolis, sambil, megacentro, agora);
            modelBuilder.Entity<CineOferta>().HasData(acropolisCineOferta, agoraCineOferta);
            modelBuilder.Entity<SalaDeCine>().HasData(salaDeCine2DMegacentro, salaDeCine3DMegacentro, salaDeCineCXCMegacentro, salaDeCine2DAcropolis, salaDeCine2DAgora, salaDeCine3DAgora, salaDeCine2DSambil, salaDeCine3DSambil);


            var avengers = new Pelicula()
            {
                idPelicula = 1,
                sTitulo = "Avengers",
                bSiNoCartelera = false,
                dFechaEstreno = new DateTime(2012, 4, 11),
                sPosterUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
            };

            var entidadGeneroPelicula = "GeneroPelicula";
            var generoIdPropiedad = "GenerosidGenero";
            var peliculaIdPropiedad = "PeliculasidPelicula";

            var entidadSalaDeCinePelicula = "PeliculaSalaDeCine";
            var salaDeCineIdPropiedad = "SalasDeCineidSalaCine";

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
                new Dictionary<string, object> { [generoIdPropiedad] = acción.idGenero, [peliculaIdPropiedad] = avengers.idPelicula },
                new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.idGenero, [peliculaIdPropiedad] = avengers.idPelicula }
            );

            var coco = new Pelicula()
            {
                idPelicula = 2,
                sTitulo = "Coco",
                bSiNoCartelera = false,
                dFechaEstreno = new DateTime(2017, 11, 22),
                sPosterUrl = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = animación.idGenero, [peliculaIdPropiedad] = coco.idPelicula }
           );

            var noWayHome = new Pelicula()
            {
                idPelicula = 3,
                sTitulo = "Spider-Man: No way home",
                bSiNoCartelera = false,
                dFechaEstreno = new DateTime(2021, 12, 17),
                sPosterUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.idGenero, [peliculaIdPropiedad] = noWayHome.idPelicula },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.idGenero, [peliculaIdPropiedad] = noWayHome.idPelicula },
               new Dictionary<string, object> { [generoIdPropiedad] = comedia.idGenero, [peliculaIdPropiedad] = noWayHome.idPelicula }
           );

            var farFromHome = new Pelicula()
            {
                idPelicula = 4,
                sTitulo = "Spider-Man: Far From Home",
                bSiNoCartelera = false,
                dFechaEstreno = new DateTime(2019, 7, 2),
                sPosterUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.idGenero, [peliculaIdPropiedad] = farFromHome.idPelicula },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.idGenero, [peliculaIdPropiedad] = farFromHome.idPelicula },
               new Dictionary<string, object> { [generoIdPropiedad] = comedia.idGenero, [peliculaIdPropiedad] = farFromHome.idPelicula }
           );

            // Para matrix pongo la fecha en el futuro

            var theMatrixResurrections = new Pelicula()
            {
                idPelicula = 5,
                sTitulo = "The Matrix Resurrections",
                bSiNoCartelera = true,
                dFechaEstreno = new DateTime(2100, 1, 1),
                sPosterUrl = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
              new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.idGenero, [peliculaIdPropiedad] = theMatrixResurrections.idPelicula },
              new Dictionary<string, object> { [generoIdPropiedad] = acción.idGenero, [peliculaIdPropiedad] = theMatrixResurrections.idPelicula },
              new Dictionary<string, object> { [generoIdPropiedad] = drama.idGenero, [peliculaIdPropiedad] = theMatrixResurrections.idPelicula }
          );

            modelBuilder.Entity(entidadSalaDeCinePelicula).HasData(
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DSambil.idSalaCine, [peliculaIdPropiedad] = theMatrixResurrections.idPelicula },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DSambil.idSalaCine, [peliculaIdPropiedad] = theMatrixResurrections.idPelicula },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DAgora.idSalaCine, [peliculaIdPropiedad] = theMatrixResurrections.idPelicula },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DAgora.idSalaCine, [peliculaIdPropiedad] = theMatrixResurrections.idPelicula },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DMegacentro.idSalaCine, [peliculaIdPropiedad] = theMatrixResurrections.idPelicula },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DMegacentro.idSalaCine, [peliculaIdPropiedad] = theMatrixResurrections.idPelicula },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCineCXCMegacentro.idSalaCine, [peliculaIdPropiedad] = theMatrixResurrections.idPelicula }
         );


            var keanuReevesMatrix = new PeliculaActor
            {
                ActorId = keanuReeves.idActor,
                PeliculaId = theMatrixResurrections.idPelicula,
                iOrden = 1,
                sPersonaje = "Neo"
            };

            var avengersChrisEvans = new PeliculaActor
            {
                ActorId = chrisEvans.idActor,
                PeliculaId = avengers.idPelicula,
                iOrden = 1,
                sPersonaje = "Capitán América"
            };

            var avengersRobertDowney = new PeliculaActor
            {
                ActorId = robertDowney.idActor,
                PeliculaId = avengers.idPelicula,
                iOrden = 2,
                sPersonaje = "Iron Man"
            };

            var avengersScarlettJohansson = new PeliculaActor
            {
                ActorId = scarlettJohansson.idActor,
                PeliculaId = avengers.idPelicula,
                iOrden = 3,
                sPersonaje = "Black Widow"
            };

            var tomHollandFFH = new PeliculaActor
            {
                ActorId = tomHolland.idActor,
                PeliculaId = farFromHome.idPelicula,
                iOrden = 1,
                sPersonaje = "Peter Parker"
            };

            var tomHollandNWH = new PeliculaActor
            {
                ActorId = tomHolland.idActor,
                PeliculaId = noWayHome.idPelicula,
                iOrden = 1,
                sPersonaje = "Peter Parker"
            };

            var samuelJacksonFFH = new PeliculaActor
            {
                ActorId = samuelJackson.idActor,
                PeliculaId = farFromHome.idPelicula,
                iOrden = 2,
                sPersonaje = "Samuel L. Jackson"
            };

            modelBuilder.Entity<Pelicula>().HasData(avengers, coco, noWayHome, farFromHome, theMatrixResurrections);
            modelBuilder.Entity<PeliculaActor>().HasData(samuelJacksonFFH, tomHollandFFH, tomHollandNWH, avengersRobertDowney, avengersScarlettJohansson,
                avengersChrisEvans, keanuReevesMatrix);

        }
    }
}
