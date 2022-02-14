using System;
using RestaurantCollection.WebApi.Exceptions;
using RestaurantCollection.WebApi.Models;

namespace RestaurantCollection.WebApi.Validators
{

    public interface IValidateUpdateRestaurant
    {
        void ValidateRestaurantDAOUpdate(Restaurant restaurant);
    }
    public class ValidateUpdateRestaurant : IValidateUpdateRestaurant
    {
        public ValidateUpdateRestaurant()
        {
        }

        public void ValidateRestaurantDAOUpdate(Restaurant restaurant)
        {
            if (restaurant != null)
            {
                if (restaurant.Id > 0)
                    throw new ReturnValidatorString("Id is not allowed while update", new Exception());
                if (!string.IsNullOrWhiteSpace(restaurant.Name))
                    throw new ReturnValidatorString("Name is not allowed while update", new Exception());
                if (restaurant.EstimatedCost > 0)
                    throw new ReturnValidatorString("EstimatedCost is not allowed while update", new Exception());
                if (!string.IsNullOrWhiteSpace(restaurant.City))
                    throw new ReturnValidatorString("City is not allowed while update", new Exception());
            }
            else
                throw new ReturnValidatorString("Request is empty", new Exception());
        }
    }
}
