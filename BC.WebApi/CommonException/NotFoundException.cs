namespace BC.WebApi.CommonException
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base("No values has been found")
        {

        }
        public NotFoundException(string message, string errorCode = "404") : base(message, errorCode)
        {

        }
    }
}
