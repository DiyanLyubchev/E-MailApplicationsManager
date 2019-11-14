using E_MailApplicationsManager.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.ViewComponents
{
    public class ManagerViewComponent : ViewComponent
    {

        private readonly IUserService service;

        public ManagerViewComponent(IUserService service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userID = UserClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentUser = await this.service.GetUserAsync(userID);

            return View(currentUser);
        }
    }
}
