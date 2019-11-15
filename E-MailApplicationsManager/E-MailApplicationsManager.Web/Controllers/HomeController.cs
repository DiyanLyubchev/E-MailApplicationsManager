using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Authorization;
>>>>>>> master

namespace E_MailApplicationsManager.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return LocalRedirect("~/identity/account/login");
            }
            return View();
        }

    }
}
