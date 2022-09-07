using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GenerosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            return await context.Generos/*.AsNoTracking()*/.OrderBy(g => g.Nombre).ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.idGenero == id);
            return genero is null ? NotFound() : genero;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Genero genero)
        {
            var estatus1 = context.Entry(genero).State;
            context.Add(genero);
            var estatus2 = context.Entry(genero).State;
            await context.SaveChangesAsync();
            var estatus3 = context.Entry(genero).State;
            return Ok();
        }

        [HttpPost("insertarVarios")]
        public async Task<ActionResult> Post(Genero[] generos)
        {
            context.AddRange(generos);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("primer")]
        public async Task<ActionResult<Genero>> Primer()
        {
            //return await context.Generos.FirstAsync();
            //return await context.Generos.FirstAsync(g => g.Nombre.StartsWith("C"));
            var genero = await context.Generos.FirstOrDefaultAsync(g => g.Nombre.StartsWith("C"));
            /*reemplazo, antes se usaba == null, ahora: is null*/
            return genero is null ? NotFound() : genero;
        }
        [HttpGet("filtrar")]
        public async Task<IEnumerable<Genero>> filtrar(string sNombre)
        {
            return await context.Generos
                //.OrderBy(g => g.Nombre)
                .Where(g => g.Nombre.Contains(sNombre))
                .OrderByDescending(g => g.Nombre)
                .ToListAsync();
        }
        [HttpGet("paginacion")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetPaginacion(int pagina = 1) 
        {
            int cantidadRegistrosPorPagina = 2;
            var generos = await context.Generos
                .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                .Take(cantidadRegistrosPorPagina)
                .ToListAsync();
            return generos;
        }

    }
}
