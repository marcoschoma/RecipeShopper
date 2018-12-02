using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Recipe;
using MBC.RecipeShopper.Dbo.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MBC.RecipeShopper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {

        private readonly IRecipeApplicationService _service;

        public RecipeController(IRecipeApplicationService service)
        {
            _service = service;
        }

        // GET api/Recipe
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // GET api/Recipe/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST api/Recipe
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertRecipeCommand command)
        {
            var result = await _service.InsertAsync(command);
            return Ok(result);
        }

        // PUT api/Recipe/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateRecipeCommand command)
        {
            var result = await _service.UpdateAsync(command);
            return Ok(result);
        }

        // DELETE api/Recipe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteByIdAsync(id);
            return Ok(result);
        }
    }
}
