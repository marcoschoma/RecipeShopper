using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.ShoplistIngredient;
using MBC.RecipeShopper.Dbo.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MBC.RecipeShopper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoplistIngredientController : ControllerBase
    {
        private readonly IShoplistIngredientApplicationService _service;

        public ShoplistIngredientController(IShoplistIngredientApplicationService service)
        {
            _service = service;
        }

        // GET api/ShoplistIngredient
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // GET api/ShoplistIngredient/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST api/ShoplistIngredient
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertShoplistIngredientCommand command)
        {
            var result = await _service.InsertAsync(command);
            return Ok(result);
        }

        // PUT api/ShoplistIngredient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateShoplistIngredientCommand command)
        {
            command.Id = id;
            var result = await _service.UpdateAsync(command);
            return Ok(result);
        }

        // DELETE api/ShoplistIngredient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteByIdAsync(id);
            return Ok(result);
        }
    }
}