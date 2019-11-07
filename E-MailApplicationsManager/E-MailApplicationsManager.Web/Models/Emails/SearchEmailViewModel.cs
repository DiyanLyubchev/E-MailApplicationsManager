using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
