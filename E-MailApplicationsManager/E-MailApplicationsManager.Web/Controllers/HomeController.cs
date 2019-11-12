using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E_MailApplicationsManager.Web.Models;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Web.Models.Message;

namespace E_MailApplicationsManager.Web.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return LocalRedirect("~/identity/account/login");
                }
                return View();
            }
            catch (UserExeption)
            {

                return View("Message", new MessageViewModel { Message = "Your name does not exist!" });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
