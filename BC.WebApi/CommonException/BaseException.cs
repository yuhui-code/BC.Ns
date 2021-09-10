namespace BC.WebApi.CommonException
{
    public abstract class BaseException : System.Exception
    {
        public string CustomErrorCode { get; set; }

        public BaseException(string message, string errorCode = "500") : base(message)
        {
            CustomErrorCode = errorCode;
        }
    }
}
