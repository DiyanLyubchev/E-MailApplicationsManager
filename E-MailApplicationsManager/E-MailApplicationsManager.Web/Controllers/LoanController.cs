using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Web.Models.Emails;
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

                await this.loanService.FillInFormForLoanAsync(loanDto);
            }
            catch (LoanExeption ex)
            {

                return View("Message", new MessageViewModel { Message = ex.Message });
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
    }
}