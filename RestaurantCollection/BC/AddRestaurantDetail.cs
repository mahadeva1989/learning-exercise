using System;
using System.Threading.Tasks;
using RestaurantCollection.WebApi.DataAccess;
using RestaurantCollection.WebApi.Exceptions;
using RestaurantCollection.WebApi.Models;

namespace RestaurantCollection.WebApi.BC
{
    public interface IAddRestaurantDetail
    {
        Task<Restaurant> AddRestaurant(Restaurant restaurant);

    }
    public class AddRestaurantDetail : IAddRestaurantDetail
    {

        private IRepository _rePository;
        public AddRestaurantDetail(IRepository rePository)
        {
            _rePository = rePository;
        }

        public async Task<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            try
            {
                return await _rePository.AddRestaurant(restaurant);
            }
            catch (Exception ex)
            {

                throw new ReturnValidatorString("Invalid Request", ex);
            }

        }
    }
}
