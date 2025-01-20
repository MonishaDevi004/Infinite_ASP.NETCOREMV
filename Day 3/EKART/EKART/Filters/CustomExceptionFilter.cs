using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EKART.Filters
{
    public class CustomExceptionFilter :IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var error = new ErrorModel(500, context.Exception.Message, context.Exception.StackTrace);
            context.Result = new JsonResult(error);
        }
    }
}
