using CrmBrusnika.Context;
using CrmBrusnika.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

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


        [HttpPut("{id}")]
        public async Task<IResult> PutTodoItem(Guid id, Land todoItem)
        {
            if (id != todoItem.Id)
            {
                return Results.BadRequest("land ID mismatch");
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetLand(Guid id)
        {
            try
            {
                var result = await _context.Lands.FindAsync(id);

                if (result == null)
                {
                    return Results.NotFound(result);
                }
                return Results.Ok(result);
            }
            catch (Exception)
            {
                throw new Exception();
            }
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
    }
}
