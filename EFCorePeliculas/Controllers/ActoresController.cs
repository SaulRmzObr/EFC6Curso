using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCorePeliculas.DTOs;
using EFCorePeliculas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EFCorePeliculas.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorDTO>> Get()
        {
            //context.Actores.Select(a => new ActorDTO { Id = a.idActor ,Nombre = a.sNombre}).ToListAsync();
            return await context.Actores.ProjectTo<ActorDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(ActorCreacionDTO actorCreacionDTO, int idActorActualizar)
        {
            var actorDb = await context.Actores.AsTracking().FirstOrDefaultAsync(actor => actor.idActor == idActorActualizar);

            if(actorDb is null)
            {
                return NotFound();
            }

            actorDb = mapper.Map(actorCreacionDTO,actorDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
