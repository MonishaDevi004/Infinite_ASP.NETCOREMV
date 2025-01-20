using EKART.Models;
using EKART.Repository;
using EKART.ViewModel;
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

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(loginViewModel);
                }

                var customerDto = await _authRepository.Login(loginViewModel.Username, loginViewModel.Password);

                if (customerDto.CustomerId != null && customerDto.RoleName != null)
                {
                    // Store minimal required information in session
                    HttpContext.Session.SetString("CustomerId", customerDto.CustomerId);
                    HttpContext.Session.SetString("Role", customerDto.RoleName);

                    return RedirectToAction("DisplayProducts", "Product");
                }

                ModelState.AddModelError("", "Invalid username, password, or role");
                return View(loginViewModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred during login. Please try again.");
                return View(loginViewModel);
            }
        }





        public IActionResult Logout()
        {
            return View();
        }

    }
}
