using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/cines")]
    public class CinesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CinesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CineDTO>> Get()
        {
            //return await context.Cines.Select(c => new CineDTO { idCine = c.idCine, sNombre = c.sNombre, dLatitud = c.Ubicacion.Y, dLongitud = c.Ubicacion.X }).ToListAsync();
            return await context.Cines.ProjectTo<CineDTO>(mapper.ConfigurationProvider).ToListAsync();
        }
        [HttpGet("cercanos")]
        public async Task<ActionResult> Get(double dLatitud, double dLongitud)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var miUbicacion = geometryFactory.CreatePoint(new Coordinate(dLongitud, dLatitud));
            var distanciaMaximaEnMetros = 2000;
            var cines = await context.Cines
                .OrderBy(c => c.Ubicacion.Distance(miUbicacion))
                .Where(c => c.Ubicacion.IsWithinDistance(miUbicacion, distanciaMaximaEnMetros))
                .Select(c => new { Nombre = c.sNombre, Distance = Math.Round(c.Ubicacion.Distance(miUbicacion)) })
                .ToListAsync();
            return Ok(cines);
        }
    }
}
