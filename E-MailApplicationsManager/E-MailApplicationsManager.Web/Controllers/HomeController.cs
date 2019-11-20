using E_MailApplicationsManager.Models.Common;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Web.Models.Emails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace E_MailApplicationsManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchService searchService;

        public HomeController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return LocalRedirect("~/identity/account/login");
            }
            return View();
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
