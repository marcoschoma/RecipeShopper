using MBC.RecipeShopper.Dbo.Domain.Commands.Inputs.Shoplist;
using MBC.RecipeShopper.Dbo.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MBC.RecipeShopper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoplistController : ControllerBase
    {
        private readonly IShoplistApplicationService _service;

        public ShoplistController(IShoplistApplicationService service)
        {
            _service = service;
        }

        // GET api/Shoplist
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // GET api/Shoplist/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST api/Shoplist
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertShoplistWithIngredientsCommand command)
        {
            var result = await _service.CreateShoplistWithIngredientsAsync(command);
            return Ok(result);
        }

        // PUT api/Shoplist/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateShoplistCommand command)
        {
            command.Id = id;
            var result = await _service.UpdateAsync(command);
            return Ok(result);
        }

        // DELETE api/Shoplist/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteByIdAsync(id);
            return Ok(result);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateShoplistWithIngredients(InsertShoplistWithIngredientsCommand command)
        //{
        //    var result = await _service.CreateShoplistWithIngredientsAsync(command);
        //    return Ok(result);
        //}
    }
}