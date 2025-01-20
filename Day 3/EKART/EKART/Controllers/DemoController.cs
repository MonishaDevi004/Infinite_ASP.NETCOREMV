using EKART.Models;
using Microsoft.AspNetCore.Mvc;

namespace EKART.Controllers
{
    //controller - is a collection of action method
    public class DemoController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public string NormalMethod()
        {
            return "I am a non action method";
        }

        //ViewResult - returns only view
        public ViewResult DisplayView()
        {
            return View();
        }
        public ContentResult DisplayContent()
        {
            return Content("<div><h1>I am from ContentResult</h1></div>", "text/html");
        }

        public JsonResult DisplayJson()
        {
            Student student = new Student()
            {
                StudentId = 1,
                StudentName = "SAI",
                StudentEmail = "sai@example.com"

            };

            return Json(student);

        }

        [NonAction]
        public EmptyResult SI()
        {
            double SI = (8900 * 2 * 3) / 100;
            return new EmptyResult();
        }


    }
}
