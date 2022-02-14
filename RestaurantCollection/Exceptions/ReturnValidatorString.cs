using System;
namespace RestaurantCollection.WebApi.Exceptions
{
    public class ReturnValidatorString : Exception
    {
        public ReturnValidatorString(string exceptionString, Exception exception) : base(exceptionString, exception)
        {

        }
    }
}
