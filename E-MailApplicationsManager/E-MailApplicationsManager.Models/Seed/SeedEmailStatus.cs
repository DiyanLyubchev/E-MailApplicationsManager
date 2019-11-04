using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.Models.Seed
{
    public static class SeedEmailStatus
    {
        public static void SeedStatuses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailStatus>().HasData(CreateStatuses());

        }

        private static EmailStatus[] CreateStatuses()
        {
            return new EmailStatus[]
            {
                new EmailStatus
                {
                     Id= 1,
                     Status="Not Reviewed"
                },
                new EmailStatus
                {
                     Id= 2,
                     Status="Invalid Application"
                },
                new EmailStatus
                {
                     Id= 3,
                     Status="New"
                },
                new EmailStatus
                {
                     Id= 4,
                     Status="Open"
                },
                new EmailStatus
                {
                     Id= 5,
                     Status="Closed"
                },
            };
            
        }
    }
}
