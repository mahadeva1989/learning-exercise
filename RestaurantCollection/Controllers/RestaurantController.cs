

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantCollection.WebApi.BC;
using RestaurantCollection.WebApi.Models;

namespace RestaurantCollection.WebApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class RestaurantController : ControllerBase
    {
        private IGetRestaurantDetail _getRestaurantDetail;
        private IAddRestaurantDetail _addRestaurantDetail;
        private IDeleteRestaurantDetail _deleteRestaurantDetail;
        private IUpdateRestaurantDetail _updateRestaurantDetail;

        public RestaurantController(
            IUpdateRestaurantDetail updateRestaurantDetail
            , IDeleteRestaurantDetail deleteRestaurantDetail
             , IAddRestaurantDetail addRestaurantDetail
            , IGetRestaurantDetail getRestaurantDetail)
        {
            _getRestaurantDetail = getRestaurantDetail;
            _addRestaurantDetail = addRestaurantDetail;
            _deleteRestaurantDetail = deleteRestaurantDetail;
            _updateRestaurantDetail = updateRestaurantDetail;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var restaurantList = await _getRestaurantDetail.GetRestaurantsList();
            return Ok(restaurantList);
        }

        [HttpGet("{id}")]
        public Task<IActionResult> Get(int id)
        {
            var restaurantList = _getRestaurantDetail.GetRestaurantsListWithId(id);
            return Ok(restaurantList);

        }


        [HttpGet("{query}")]
        public async Task<IActionResult> Get([FromQuery] RestaurantQueryModel query)
        {
            var restaurantList = await _getRestaurantDetail.GetRestaurantsListWithFilters(query);
            return Ok(restaurantList);

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Restaurant restaurant)
        {
            var restaurantList = await _addRestaurantDetail.AddRestaurant(restaurant);
            return Created("", restaurantList);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _deleteRestaurantDetail.DeleteRestaurant(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Sort()
        {
            var response = await _getRestaurantDetail.GetRestaurantsListWithSort();
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Restaurant restaurant)
        {

            var response = await _updateRestaurantDetail.UpdateRestaurant(restaurant, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }




    }

}