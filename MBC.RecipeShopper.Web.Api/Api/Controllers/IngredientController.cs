using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Ingredient;
using MBC.RecipeShopper.Dbo.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MBC.RecipeShopper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {

        private readonly IIngredientApplicationService _service;

        public IngredientController(IIngredientApplicationService service)
        {
            _service = service;
        }

        // GET api/Ingredient
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // GET api/Ingredient/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST api/Ingredient
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertIngredientCommand command)
        {
            var result = await _service.InsertAsync(command);
            return Ok(result);
        }

        // PUT api/Ingredient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateIngredientCommand command)
        {
            command.Id = id;
            var result = await _service.UpdateAsync(command);
            return Ok(result);
        }

        // DELETE api/Ingredient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteByIdAsync(id);
            return Ok(result);
        }
    }
}
