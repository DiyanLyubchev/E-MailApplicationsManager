﻿using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace E_MailApplicationsManager.Service.Service
{
    public class LoanService : ILoanService
    {
        private readonly E_MailApplicationsManagerContext context;

        private readonly IEncodeDecodeService encodeDecodeService;

        public LoanService(E_MailApplicationsManagerContext context, IEncodeDecodeService encodeDecodeService)
        {
            this.context = context;
            this.encodeDecodeService = encodeDecodeService;
        }


        public async Task<LoanApplicant> FillInFormForLoan(LoanApplicantDto loanApplicantDto)
        {
            if (loanApplicantDto.Name == null ||
                loanApplicantDto.EGN == null
                || loanApplicantDto.PhoneNumber == null)
            {
                throw new LoanExeption("Тhe details of the loan request have not been filled in correctly");

            }

            var user = await this.context.Users
                .Include(l => l.LoanApplicant)
                .Where(userId => userId.Id == loanApplicantDto.userId)
                .FirstOrDefaultAsync();


            var encodeName = this.encodeDecodeService.Base64Encode(loanApplicantDto.Name);
            var encodeEGN = this.encodeDecodeService.Base64Encode(loanApplicantDto.EGN);
            var encodePhoneNumber = this.encodeDecodeService.Base64Encode(loanApplicantDto.PhoneNumber);

            var loanApplicant = await this.context.LoanApplicants
                .Where(egn => egn.EGN == encodeEGN)
                .FirstOrDefaultAsync();

            if (loanApplicant == null)
            {
                var loan = new LoanApplicant
                {
                    Name = encodeName,
                    EGN = encodeEGN,
                    PhoneNumber = encodePhoneNumber,
                    UserId = loanApplicantDto.userId,
                    User = user
                };

                await this.context.LoanApplicants.AddAsync(loan);
                await this.context.SaveChangesAsync();
                return loan;
            }

            return null;
        }
    }
}