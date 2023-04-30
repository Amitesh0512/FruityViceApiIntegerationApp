using FruityViceApiIntegerationApp.Interfaces;
using FruityViceApiIntegerationApp.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruityViceApiIntegerationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruityViceAppController : ControllerBase
    {

        private readonly IGetAllFruits _getAllFruits;
        private readonly IGetFruitsByGenus _getFruitsByGenus;

        public FruityViceAppController(
            IGetAllFruits getAllFruits,
            IGetFruitsByGenus getFruitsByGenus
            )
        {
            _getAllFruits = getAllFruits;
            _getFruitsByGenus = getFruitsByGenus;
        }

        [HttpGet]
        public async Task<ActionResult<AllFruitsResponse>> GetAllFruits()
        {
            try
            {
                AllFruitsResponse response = await _getAllFruits.GetAllFruitsAsync();
                return Ok(response);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetFruitsByGenusFinalResponse>> GetFruitsByGenus(string family)
        {
            try
            {
                if (string.IsNullOrEmpty(family))
                {
                    return BadRequest("Please enter a Fruit Family");
                }
                GetFruitsByGenusFinalResponse response = await _getFruitsByGenus.GetFruitsByFamilyAsync(family);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
