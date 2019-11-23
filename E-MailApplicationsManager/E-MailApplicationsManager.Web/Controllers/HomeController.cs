using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Web.Models.Emails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

            var viewModel = new ListEmailsFromChartViewModel(list);

            return Json(viewModel);
        }
    }
}
