namespace BC.WebApi.CommonException
{
    public class ForbiddenException : BaseException
    {
        public ForbiddenException() : base("Forbidden.")
        {

        }
        public ForbiddenException(string message, string errorCode = "403") : base(message, errorCode)
        {

        }
    }
}
