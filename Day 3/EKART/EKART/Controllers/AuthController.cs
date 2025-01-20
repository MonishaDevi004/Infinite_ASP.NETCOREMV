using EKART.Models;
using EKART.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EKART.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly NorthwindContext northwindContext;
        public AuthController(IAuthRepository authRepository,NorthwindContext _northwindContext)
        {
            _authRepository = authRepository;
            northwindContext = _northwindContext;
        }
        
        public IActionResult CustomerLogin(string CustomerID = "ANATR" , string Password = "123")
        {

              var customer = _authRepository.Login(CustomerID, Password);
              if (customer != null)
              {
                  // Customer login successful
                  return RedirectToAction("DisplayProducts", "Product");
              }

            
            return View(); 
        }


    }
}
