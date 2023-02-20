using Microsoft.AspNetCore.Http;

namespace BookStore.BLL.ErrorHandling
{
    public class ApiStatusCodeResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiStatusCodeResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => " Not Authorized",
                404 => "Resource not found",
                500 => "Internal eror",
                _ => null
            };
        }
    }
}
