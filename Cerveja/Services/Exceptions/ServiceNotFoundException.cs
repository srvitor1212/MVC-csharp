namespace Cerveja.Services.Exceptions
{
    public class ServiceNotFoundException : ApplicationException
    {
        public ServiceNotFoundException(string msg) : base(msg)
        {

        }
    }
}
