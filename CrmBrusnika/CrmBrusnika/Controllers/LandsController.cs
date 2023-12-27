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
    public class LandsController
    {
        private readonly LandsContext _context;

        public LandsController(LandsContext context)
        {
            _context = context;
        }

        [Route("create")]
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

        /*[Route("put")]
        [HttpPut()]
        public async Task<IResult> UpdateLand(Guid id, Land land)
        {
            try
            {
                if (id != land.Id)
                    return Results.BadRequest("land ID mismatch");

                var landToUpdate = await GetLand(id);
                
                if (landToUpdate == null)
                    return Results.NotFound($"Land with Id = {id} not found");

                await _context.Lands.Update(land);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }*/

        [Route("get-land")]
        [HttpGet()]
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

        [Route("")]
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
