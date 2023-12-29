using CrmBrusnika.Context;
using CrmBrusnika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmBrusnika.Controllers
{
    [Route("api/entities/")]
    [ApiController]
    public class ObjectEntitiesController : ControllerBase
    {
        private readonly ObjectEntitiesContext _context;

        public ObjectEntitiesController(ObjectEntitiesContext context)
        {
            _context = context;
        }

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
            var response = await _context.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return newEntity;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectEntity>> GetEntity(Guid id)
        {
            var entity = await _context.ObjectEntities.FindAsync(id);

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
                return await _context.ObjectEntities.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
