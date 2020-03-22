using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthyLife.Data;
using HealthyLife.Domain.Food;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using System.Net;

namespace HealthyLife.API.Controllers
{
    [EnableQuery]
    public class IngredientsController : ODataController
    {
        private readonly FoodContext _context;

        public IngredientsController(FoodContext context)
        {
            _context = context;
        }

        // GET: odata/Ingredients
        public IQueryable<Ingredient> Get()
        {
            return _context.Ingredients.AsQueryable();
        }

        // GET: odata/Ingredients(5)
        public SingleResult<Ingredient> Get([FromODataUri] int key)
        {
            var ingredient = _context.Ingredients.Where(i => i.Id == key);
            return SingleResult.Create(ingredient);
        }

        // POST: odata/Ingredients
        public async Task<IActionResult> Post([FromBody] Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return Created(ingredient);
        }

        // PATCH: odata/Ingredients(5)
        public async Task<IActionResult> Patch([FromODataUri] int key, Delta<Ingredient> ingredient)
        {
            var entity = await _context.Ingredients.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            ingredient.Patch(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }

        // DELETE: odata/Ingredients(5)
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            var ingredient = await _context.Ingredients.FindAsync(key);
            if (ingredient == null)
            {
                return NotFound();
            }
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool IngredientExists(int key)
        {
            return _context.Ingredients.Any(i => i.Id == key);
        }
    }
}
