using CrmBrusnika.Context;
using CrmBrusnika.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmBrusnika.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/entities/")]
    [ApiController]
    public class ObjectEntitiesController : ControllerBase
    {
        private readonly LandsContext _context;

        public ObjectEntitiesController(LandsContext context)
        {
            _context = context;
        }
        private bool LandExists(Guid id) => _context.Lands.Any(e => e.Id == id);
        private bool EntityExists(Guid id) => _context.Entities.Any(e => e.Id == id);

        [HttpPost]
        public async Task<ActionResult<ObjectEntity>> createEntity(ObjectEntity entity)
        {
            var newEntity = new ObjectEntity(
                entity.JuridicalCost,
                entity.PermissiveSide,
                entity.GeotechnicalConditions,
                entity.AvailabilityEngineeringNetworks,
                entity.TransportationaAccessibility
            );
            if (!LandExists(entity.LandId))
                return NotFound("Land is not found");
            newEntity.LandId = entity.LandId;
            newEntity.Land = await _context.Lands.FindAsync(entity.LandId);

            var response = await _context.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return newEntity;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectEntity>> GetEntity(Guid id)
        {
            var entity = await _context.Entities
                .Include(e => e.Land)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpGet()]
        public async Task<IEnumerable<ObjectEntity>> GetEntities()
        {
            try
            {
                var res = new List<ObjectEntity>();
                foreach (var el in await _context.Entities.ToListAsync())
                {
                    el.Land = await _context.Lands.FindAsync(el.LandId);
                    res.Add(el);
                }
                return res;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ObjectEntity>> PutLand(Guid id, ObjectEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest(entity);
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateConcurrencyException) when (!EntityExists(id))
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ObjectEntity>> DeleteEntity(Guid id)
        {
            var entity = await _context.Entities.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Entities.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
