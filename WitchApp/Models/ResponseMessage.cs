namespace WitchApp.Models
{
    public class ResponseMessage<T>
    {
        public bool Success { get; set; }
        public ResponseStatus Status { get; set; }
        public string StatusText { get { return Status.ToString(); } }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public object? ModelState { get; set; }
    }

    public enum ResponseStatus
    {
        Success,
        Confirm,
        Warning,
        Error
    }
}
