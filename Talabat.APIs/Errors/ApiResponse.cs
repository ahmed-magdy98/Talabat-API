namespace Talabat.APIs.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode= statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request, you have made",
                401 => "UnAuthorized, you are not",
                404 => "Resource was not found",
                500 => "Error are the path to dark side. errors lead to anger. Anger leads to hate. Hate leads to career change"
            };
        }
    }
}
