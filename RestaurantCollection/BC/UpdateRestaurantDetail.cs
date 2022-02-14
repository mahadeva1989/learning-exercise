using System;
using System.Threading.Tasks;
using RestaurantCollection.WebApi.DataAccess;
using RestaurantCollection.WebApi.Models;
using RestaurantCollection.WebApi.Validators;

namespace RestaurantCollection.WebApi.BC
{
    public interface IUpdateRestaurantDetail
    {
        Task<Restaurant> UpdateRestaurant(Restaurant restaurant, int id);

    }
    public class UpdateRestaurantDetail : IUpdateRestaurantDetail
    {
        private IRepository _rePository;
        private IValidateUpdateRestaurant _validateUpdateRestaurant;
        public UpdateRestaurantDetail(IRepository rePository, IValidateUpdateRestaurant validateUpdateRestaurant)
        {
            _rePository = rePository;
            _validateUpdateRestaurant = validateUpdateRestaurant;
        }

        public async Task<Restaurant> UpdateRestaurant(Restaurant restaurant, int id)
        {
            _validateUpdateRestaurant.ValidateRestaurantDAOUpdate(restaurant);
            try
            {
                restaurant.Id = id;
                return await _rePository.UpdateRestaurant(restaurant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
    }
}
