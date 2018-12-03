using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.RecipeIngredient;
using MBC.RecipeShopper.Dbo.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MBC.RecipeShopper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {

        private readonly IRecipeIngredientApplicationService _service;

        public RecipeIngredientController(IRecipeIngredientApplicationService service)
        {
            _service = service;
        }

        // GET api/RecipeIngredient
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // GET api/RecipeIngredient/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST api/RecipeIngredient
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertRecipeIngredientCommand command)
        {
            var result = await _service.InsertAsync(command);
            return Ok(result);
        }

        // PUT api/RecipeIngredient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateRecipeIngredientCommand command)
        {
            command.Id = id;
            var result = await _service.UpdateAsync(command);
            return Ok(result);
        }

        // DELETE api/RecipeIngredient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteByIdAsync(id);
            return Ok(result);
        }
    }
}
