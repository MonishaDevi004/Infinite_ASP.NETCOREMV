using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace EKART.Filters
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public string? Details { get; set; }

        public ErrorModel(int statusCode, string? messaage,string? details)
        {
            StatusCode = statusCode;
            Message = messaage;
            Details = details;

        }
    }
}
