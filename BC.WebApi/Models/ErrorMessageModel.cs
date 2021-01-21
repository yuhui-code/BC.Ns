namespace BC.WebApi.Models
{
    public class ErrorMessageModel
    {
        public string UserMessage { get; set; }

        public string InternalMessage { get; set; }

        public string CustomErrorCode { get; set; }

        public string MoreInfo { get; set; }
    }
}
