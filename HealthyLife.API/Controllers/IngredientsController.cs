using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.OData;
using HealthyLife.Data.Entities.Food;
using HealthyLife.Models.Food;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HealthyLife.Data.DbContexts;

namespace HealthyLife.API.Controllers
{
    [EnableQuery]
    public class IngredientsController : ODataController
    {
        private readonly FoodContext _context;
        private readonly IMapper _mapper;

        public IngredientsController(FoodContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: odata/Ingredients
        public IQueryable<IngredientModel> Get()
        {
            IQueryable<Ingredient> ingredients = _context.Ingredients.AsQueryable();
            IQueryable<IngredientModel> ingredientModels = ingredients.ProjectTo<IngredientModel>(_mapper.ConfigurationProvider);
            return ingredientModels;
        }

        // GET: odata/Ingredients(5)
        public SingleResult<IngredientModel> Get([FromODataUri] int key)
        {
            IQueryable<Ingredient> ingredient = _context.Ingredients.Where(i => i.Id == key);
            IQueryable<IngredientModel> ingredientModel = ingredient.ProjectTo<IngredientModel>(_mapper.ConfigurationProvider);
            return SingleResult.Create(ingredientModel);
        }

        // POST: odata/Ingredients
        public async Task<IActionResult> Post([FromBody] IngredientModel ingredientModel)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientModel);
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            _mapper.Map(ingredient, ingredientModel);
            return Created(ingredientModel);
        }

        // PATCH: odata/Ingredients(5)
        public async Task<IActionResult> Patch([FromODataUri] int key, Delta<IngredientModel> delta)
        {
            var ingredient = await _context.Ingredients.FindAsync(key);
            if (ingredient == null)
            {
                return NotFound();
            }
            var ingredientModel = _mapper.Map<IngredientModel>(ingredient);
            delta.Patch(ingredientModel);
            _mapper.Map(ingredientModel, ingredient);
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
            return Updated(ingredientModel);
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
