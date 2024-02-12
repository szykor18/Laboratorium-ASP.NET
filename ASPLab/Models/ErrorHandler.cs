namespace ASPLab_P.Models
{
    public class ErrorHandler
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
