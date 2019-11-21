using System.Security.Claims;
using System.Threading.Tasks;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Web.Models.Emails;
using E_MailApplicationsManager.Web.Models.Loan;
using E_MailApplicationsManager.Web.Models.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_MailApplicationsManager.Web.Controllers
{
    public class LoanController : Controller
    {
        private readonly ISearchService searchService;
        private readonly ILoanService loanService;
        private readonly IEncodeDecodeService encodeDecodeService;

        public LoanController(ILoanService loanService, ISearchService searchService, IEncodeDecodeService encodeDecodeService)
        {
            this.searchService = searchService;
            this.loanService = loanService;
            this.encodeDecodeService = encodeDecodeService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Loanform(string userData, string egnData, string phoneData, string idData)
        {
            try
            {
                var loanDto = new LoanApplicantDto
                {
                    Name = userData,
                    EGN = egnData,
                    PhoneNumber = phoneData,
                    GmailId = idData,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                var result = await this.loanService.FillInFormForLoanAsync(loanDto);

                var stop = 0;
            }
            catch (LoanExeption)
            {

                return Json(new { exeption = idData });
            }

            return Json(new { emailId = idData });
        }

        [Authorize]
        public async Task<IActionResult> ListOpenStatusEmails()
        {
            var loanApplicantDto = new LoanApplicantDto
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            var openStatusEmails = await this.searchService.ListEmailsWithStatusOpenAsync(loanApplicantDto);

            var loanList = this.encodeDecodeService.DecodeLoanApplicantList(openStatusEmails);

            var listStatusOpenEmailsViewModel = new ListStatusOpenEmailsViewModel(loanList);

            return View(listStatusOpenEmailsViewModel);
        }

        [Authorize]
        public async Task<IActionResult> LoanEmailDetails(int id)
        {
            var loan = await this.searchService.FindLoansByIdAsync(id);
            if (loan == null)
            {
                return View("Message", new MessageViewModel { Message = "The email was not found!" });
            }

            var decodeLoan = this.encodeDecodeService.DecodeLoanApplicant(loan);

            var result = new StatusOpenEmailsViewModel(decodeLoan);

            return View(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ApproveLoan(string approveData, string rejectData)
        {
            string[] expectedResult = null;
            try
            {
                if (approveData != null)
                {
                    expectedResult = approveData.Split(' ');
                    var approveDto = new ApproveLoanDto
                    {
                        IsApprove = expectedResult[0],
                        GmailId = expectedResult[1],
                        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };

                    await this.loanService.ApproveLoanAsync(approveDto);
                }
                else if (rejectData != null)
                {
                    expectedResult = rejectData.Split(' ');
                    var approveDto = new ApproveLoanDto
                    {
                        IsApprove = expectedResult[0],
                        GmailId = expectedResult[1],
                        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };

                    await this.loanService.ApproveLoanAsync(approveDto);
                }
            }
            catch (LoanExeption ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

            return Json(new { emailId = expectedResult[1] });
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetAllFinishLoan()
        {
            var closeStatusEmails = await this.searchService.GetAllFinishLoanApplicantAsync();

            var loanList = this.encodeDecodeService.DecodeLoanApplicantList(closeStatusEmails);

            var listStatusCloseEmailsViewModel = new ListStatusCloseEmailViewModel(loanList);

            return View(listStatusCloseEmailsViewModel);
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> FinishLoanDetails(int id)
        {
            var loan = await this.searchService.FindLoansByIdAsync(id);
            var nameEmployee = await this.searchService.FindByIdNameOfEmployeeAsync(id);
            var date = await this.searchService.FindByIdDateOfTerminalAsync(id);
            var resultOfLoanApplicant = await this.searchService.FindByIDIsApproveOrNotAsync(id);

            if (loan == null)
            {
                return View("Message", new MessageViewModel { Message = "The email was not found!" });
            }

            var decodeLoan = this.encodeDecodeService.DecodeLoanApplicant(loan);

            var result = new StatusCloseEmailViewModel(decodeLoan);
            result.EmployeeName = nameEmployee;
            result.TerminalDate = date;
            result.Status = resultOfLoanApplicant;

            return View(result);
        }
    }
}