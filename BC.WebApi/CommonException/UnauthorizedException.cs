namespace BC.Jwt.CommonException
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException() : base("Authentication token is not valid.")
        {

        }
        public UnauthorizedException(string message, string errorCode = "401") : base(message, errorCode)
        {

        }
    }
}
