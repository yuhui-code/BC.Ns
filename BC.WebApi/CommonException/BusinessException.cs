namespace BC.WebApi.CommonException
{
    public class BusinessException : BaseException
    {
        public BusinessException() : base("business error")
        {
        }

        public BusinessException(string message, string errorCode = "412") : base(message, errorCode)
        {
        }
    }
}
