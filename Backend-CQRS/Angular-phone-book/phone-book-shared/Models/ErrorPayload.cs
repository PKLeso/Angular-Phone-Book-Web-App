namespace phone_book_shared.Models
{
    public class ErrorPayload
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
    }
}
