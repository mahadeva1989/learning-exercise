using System;
using System.Threading.Tasks;
using RestaurantCollection.WebApi.DataAccess;
using RestaurantCollection.WebApi.Exceptions;
using RestaurantCollection.WebApi.Models;

namespace RestaurantCollection.WebApi.BC
{
    public interface IDeleteRestaurantDetail
    {
        Task<bool> DeleteRestaurant(int id);

    }
    public class DeleteRestaurantDetail : IDeleteRestaurantDetail
    {
        private IRepository _rePository;
        public DeleteRestaurantDetail(IRepository rePository)
        {
            _rePository = rePository;
        }

        public async Task<bool> DeleteRestaurant(int id)
        {
            try
            {
                return await _rePository.DeleteRestaurant(id);
            }
            catch (Exception ex)
            {
                throw new ReturnValidatorString("Invalid Request", ex);
            }

        }
    }
}
