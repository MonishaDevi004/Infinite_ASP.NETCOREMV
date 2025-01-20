using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace EKART.Filters
{
    public class LogActionFilter :ActionFilterAttribute
    {
        private Stopwatch stopwatch;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch = Stopwatch.StartNew();
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            var message = $" Action took Elapsed {elapsedMilliseconds} ms";
            Console.WriteLine(message);
        }
    }
}
