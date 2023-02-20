namespace BookStore.BLL.ErrorHandling
{
    public class ApiValidationError : ApiStatusCodeResponse
    {
        public ApiValidationError(): base(400) { }

        public IEnumerable<string> Errors { get; set; }
    }
}
