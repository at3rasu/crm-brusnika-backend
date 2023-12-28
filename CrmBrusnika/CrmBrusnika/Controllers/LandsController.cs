using CrmBrusnika.Context;
using CrmBrusnika.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmBrusnika.Controllers
{
    [Route("api/lands/")]
    [ApiController]
    public class LandsController : ControllerBase
    {
        private readonly LandsContext _context;

        public LandsController(LandsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Land>> createLand(Land land)
        {
            var newLand = new Land(
                land.RegisterNumber,
                land.Adress,
                land.AreaInMeters,
                land.AboutHolder,
                land.Price,
                land.WhoIsFound
            );
            var response = await _context.AddAsync(newLand);
            await _context.SaveChangesAsync();
            return newLand;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Land>> GetLand(Guid id)
        {
            var land = await _context.Lands.FindAsync(id);

            if (land == null)
            {
                return NotFound();
            }

            return land;
        }

        [HttpGet()]
        public async Task<IEnumerable<Land>> GetLands()
        {
            try
            {
                return await _context.Lands.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutLand(Guid id, Land land)
        {
            if (id != land.Id)
            {
                return BadRequest(land);
            }

            _context.Entry(land).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GetLand(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem(Guid id)
        {
            var todoItem = await _context.Lands.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Lands.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
