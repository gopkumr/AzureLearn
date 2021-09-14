using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
