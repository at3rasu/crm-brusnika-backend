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
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<Land>> UpdateEmployee(Guid id, Land land)
        {
            try
            {
                if (id != land.Id)
                    return BadRequest("Employee ID mismatch");

                var employeeToUpdate = await _context.(id);

                if (employeeToUpdate == null)
                    return NotFound($"Employee with Id = {id} not found");

                return await employeeRepository.UpdateEmployee(land);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
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
    }
}
