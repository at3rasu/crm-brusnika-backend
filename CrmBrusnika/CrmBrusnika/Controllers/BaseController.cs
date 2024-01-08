using CrmBrusnika.Context;
using CrmBrusnika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CrmBrusnika.Controllers
{
    public class BaseController<T>
        where T : new()
    {
        private readonly DbContext _context;

        public BaseController(DbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<T>> createLand(T item)
        {
            T newItem = Generate(item);
            var response = await _context.AddAsync(newItem);
            await _context.SaveChangesAsync();
            return newItem;
        }

        private T Generate(T item)
        {
            var result = new T();
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                property.SetValue(result, property.GetValue(item));
            }

            return result;
        }
    }
}
