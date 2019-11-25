using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.Middlewares
{
    public class NotFoundPageMiddleware
    {
        private readonly RequestDelegate next;

        public NotFoundPageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpcontext)
        {
            await this.next.Invoke(httpcontext);

            if (httpcontext.Response.StatusCode == 404)
            {
                httpcontext.Response.Redirect("/home/notfoundpage");
            }

        }
    }
}
