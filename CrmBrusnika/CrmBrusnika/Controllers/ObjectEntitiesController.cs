using CrmBrusnika.Context;
using CrmBrusnika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CrmBrusnika.Controllers
{
    [Route("api/entities/")]
    [ApiController]
    public class ObjectEntitiesController : ControllerBase
    {
        private readonly LandsContext _context;

        public ObjectEntitiesController(LandsContext context)
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
            newEntity.LandId = entity.LandId;
            newEntity.Land = await _context.Lands.FindAsync(newEntity.LandId);
            var response = await _context.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return newEntity;
        }

        /*[HttpGet("{id}")]
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
        }*/
    }
}
