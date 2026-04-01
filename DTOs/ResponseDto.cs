namespace irctc.DTOs
{
    public class ResponseDto<T>
    {
        public T? Data { get; set; }
        public string Error { get; set; } = "";
    }
}