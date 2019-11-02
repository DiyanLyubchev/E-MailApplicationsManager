using E_MailApplicationsManager.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.ViewComponents
{
    public class OperatorViewComponent : ViewComponent
    {
        private readonly IUserService service;

        public OperatorViewComponent(IUserService service)
        {

            this.service = service;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userID = UserClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentUser = await this.service.GetUserAsync(userID);

            bool exists = currentUser != null;

            return View(exists);
        }
    }
}
