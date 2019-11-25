using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Web.Models.Emails;
using E_MailApplicationsManager.Web.Models.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService searchService;

        public HomeController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return LocalRedirect("~/identity/account/login");
            }

            var allNotReviewed = await this.searchService.GetAllNotReviewedEmails();

            var result = new NotReviewedEmailsViewModel(allNotReviewed);

            return View(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetChartData()
        {
            var list = await this.searchService.GetEmailsForChart();

            return Json(list);
        }

        public IActionResult NotFoundPage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
