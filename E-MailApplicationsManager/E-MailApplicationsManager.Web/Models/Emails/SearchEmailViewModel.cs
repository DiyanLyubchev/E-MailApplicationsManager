using System.Collections.Generic;

namespace E_MailApplicationsManager.Web.Models.Emails
{
    public class SearchEmailViewModel
    {
        public SearchEmailViewModel()
        {
        }

        public SearchEmailViewModel(IEnumerable<EmailViewModel> searchViewModel)
        {
            this.Result = searchViewModel;
        }

        public IEnumerable<EmailViewModel> Result { get; set; } = new List<EmailViewModel>();


    }
}
