namespace PrecisionFarming.Domain.Exceptions
{
    public class UnauthorizedResourceAccessException : Exception
    {
        public UnauthorizedResourceAccessException(string message) : base(message)
        {
        }
    }
}
