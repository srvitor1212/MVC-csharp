namespace Cerveja.Services.Exceptions
{
    public class ServiceConcurrencyException : ApplicationException
    {
        public ServiceConcurrencyException(string msg) : base(msg)
        {

        }
    }
}
