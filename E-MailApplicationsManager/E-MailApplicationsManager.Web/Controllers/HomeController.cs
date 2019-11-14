using Microsoft.AspNetCore.Mvc;

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
