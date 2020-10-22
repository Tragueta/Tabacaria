namespace Tabacaria.Domain.Utils.HttpUtils
{
    public class Response<T> where T: class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T ResponseObject { get; set; }

        public Response() { }

        public Response(bool success, string message, T responseObject)
        {
            Success = success;
            Message = message;
            ResponseObject = responseObject;
        }
    }
}
