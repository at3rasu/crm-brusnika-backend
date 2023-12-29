using CrmBrusnika.Context;
using CrmBrusnika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            var land = await _context.Lands.FindAsync(entity.LandId);
            newEntity.Land = land;
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
    }
}
