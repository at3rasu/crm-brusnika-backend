using CrmBrusnika.Context;
using CrmBrusnika.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrmBrusnika.Controllers
{
    [Route("api/lands/")]
    [ApiController]
    public class LandsController
    {
        private readonly LandsContext _context;

        public LandsController(LandsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<Land> createLand(Land land)
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
                throw new Exception("Land is not found");
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
        public async Task<IResult> PutTodoItem(Guid id, Land land)
        {
            if (id != land.Id)
            {
                return Results.BadRequest(land);
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
                    return Results.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteTodoItem(Guid id)
        {
            var todoItem = await _context.Lands.FindAsync(id);
            if (todoItem == null)
            {
                return Results.NotFound();
            }

            _context.Lands.Remove(todoItem);
            await _context.SaveChangesAsync();

            return Results.NoContent();
        }
    }
}
