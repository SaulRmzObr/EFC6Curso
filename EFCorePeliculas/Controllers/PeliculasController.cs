using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PeliculasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> Get(int id) 
        {
            var pelicula = await context.Peliculas
            //.ProjectTo<PeliculaDTO>(mapper.ConfigurationProvider)
            .Include(p => p.Generos.OrderByDescending(g => g.Nombre))
            .Include(p => p.SalasDeCine)
                .ThenInclude(s => s.Cine)
            .Include(p => p.PeliculasActores.Where(pa => pa.Actor.dFechaNacimiento.Value.Year >= 1980))
                .ThenInclude(a => a.Actor)
            .FirstOrDefaultAsync(p => p.idPelicula == id);
            

            if (pelicula is null)
            {
                return NotFound();
            }
            var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);
            peliculaDTO.Cines = peliculaDTO.Cines.DistinctBy(c => c.idCine).ToList();
            return peliculaDTO;
        }

        [HttpGet("conprojectto/{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetConProjectTo(int id)
        {
            var pelicula = await context.Peliculas
            .ProjectTo<PeliculaDTO>(mapper.ConfigurationProvider)
            //.Include(p => p.Generos.OrderByDescending(g => g.Nombre))
            //.Include(p => p.SalasDeCine)
            //    .ThenInclude(s => s.Cine)
            //.Include(p => p.PeliculasActores.Where(pa => pa.Actor.dFechaNacimiento.Value.Year >= 1980))
            //    .ThenInclude(a => a.Actor)
            .FirstOrDefaultAsync(p => p.idPelicula == id);


            if (pelicula is null)
            {
                return NotFound();
            }
            //var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);
            pelicula.Cines = pelicula.Cines.DistinctBy(c => c.idCine).ToList();
            return pelicula;
        }

        [HttpGet("ConsultaSelectiva/{id:int}")]
        public async Task<ActionResult> GetSelectivo(int id)
        {
            var pelicula = await context.Peliculas.Select( p => 
            new { 
                Id = p.idPelicula, 
                Titulo = p.sTitulo, 
                Generos = p.Generos.OrderByDescending(g => g.Nombre).Select(g => g.Nombre).ToList(),
                CantidadActores = p.PeliculasActores.Count,
                CantidadCines = p.SalasDeCine.Select(s => s.CineId).Distinct().Count()
            }).FirstOrDefaultAsync(p => p.Id == id);
                
            if(pelicula is null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpGet("lazyLoading/{id:int}")]
        public async Task<ActionResult<List<PeliculaDTO>>> GetLazyLoading() 
        {
            var pelicula = await context.Peliculas.AsTracking().ToListAsync();
            if (pelicula is null) 
            {
                return NotFound();
            }
            var peliculasDtos = mapper.Map<List<PeliculaDTO>>(pelicula);
            return peliculasDtos;
        }

        [HttpGet("agrupadasPorEstreno")]
        public async Task<ActionResult> GetAgrupadasPorCartelera() 
        {
            var peliculasAgrupadas = await context.Peliculas
                .GroupBy(p => p.bSiNoCartelera)
                .Select( p => new {
                    EnCartelera = p.Key,
                    Conteo = p.Count(),
                    Peliculas = p.ToList()
                })
                .ToListAsync();

            if (peliculasAgrupadas is null)
            {
                return NotFound();
            }
            return Ok(peliculasAgrupadas);
        }

        [HttpGet("agrupadasPorCantidadDeGeneros")]
        public async Task<ActionResult> GetAgrupadasPorCantidadDeGeneros() 
        {
            var peliculasAgrupadas = await context.Peliculas
                .GroupBy(p => p.Generos.Count())
                .Select(p => new {
                    Conteo = p.Key, 
                    Titulos = p.Select(t => t.sTitulo),
                    Generos = p.Select(g => g.Generos).SelectMany(genero => genero).Select(genero => genero.Nombre).Distinct()
                })
                .ToListAsync();
            if (peliculasAgrupadas is null) 
            {
                return NotFound();
            }
            return Ok(peliculasAgrupadas);
        }

        [HttpGet("filtrar")]
        public async Task<ActionResult<List<PeliculaDTO>>> Filtrar([FromQuery] PeliculasFiltroDTO peliculasFiltroDTO) 
        {
            var peliculasQueryable = context.Peliculas.AsQueryable();

            if (!string.IsNullOrEmpty(peliculasFiltroDTO.Titulo)) 
            {
                peliculasQueryable = peliculasQueryable.Where(p => p.sTitulo.Contains(peliculasFiltroDTO.Titulo));
            }

            if (peliculasFiltroDTO.EnCartelera) 
            {
                peliculasQueryable = peliculasQueryable.Where(p => p.bSiNoCartelera);
            }

            if (peliculasFiltroDTO.ProximosEstrenos) 
            {
                peliculasQueryable = peliculasQueryable.Where(p => p.dFechaEstreno > DateTime.Today);
            }

            if (peliculasFiltroDTO.IdGenero != 0) 
            {
                peliculasQueryable = peliculasQueryable.Where(p => p.Generos.Select(g => g.idGenero).Contains(peliculasFiltroDTO.IdGenero));
            }

            var peliculas = await peliculasQueryable.Include(p => p.Generos).ToListAsync();

            return mapper.Map<List<PeliculaDTO>>(peliculas);

        }

    }
}
