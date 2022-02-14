using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantCollection.WebApi.DataAccess;
using RestaurantCollection.WebApi.Models;

namespace RestaurantCollection.WebApi.BC
{
    public interface IGetRestaurantDetail
    {
        Task<IEnumerable<Restaurant>> GetRestaurantsList();
        Task<IEnumerable<Restaurant>> GetRestaurantsListWithFilters(RestaurantQueryModel query);
        Task<IEnumerable<Restaurant>> GetRestaurantsListWithSort();
        Restaurant GetRestaurantsListWithId(int id);

    }
    public class GetRestaurantDetail : IGetRestaurantDetail
    {
        /// <summary>
        /// dependencies
        /// </summary>
        private IRepository _rePository;
        public GetRestaurantDetail(IRepository rePository)
        {
            _rePository = rePository;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsList()
        {
            return await _rePository.GetRestaurants();
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsListWithFilters(RestaurantQueryModel query)
        {
            return await _rePository.GetRestaurants(query);
        }

        public Restaurant GetRestaurantsListWithId(int id)
        {
            var task = GetASyncRestaurantsListWithId(id);
            try
            {
                task.Wait();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return task.Result;

        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsListWithSort()
        {
            return await _rePository.GetRestaurantsSorted();
        }

        private async Task<Restaurant> GetASyncRestaurantsListWithId(int id)
        {
            return await _rePository.GetRestaurant(id);
        }
    }
}
