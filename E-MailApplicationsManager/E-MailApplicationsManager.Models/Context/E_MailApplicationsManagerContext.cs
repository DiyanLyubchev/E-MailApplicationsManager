using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_MailApplicationsManager.Models.Context
{
    public class E_MailApplicationsManagerContext : IdentityDbContext<User>
    {
        public E_MailApplicationsManagerContext()
        {
        }
        public E_MailApplicationsManagerContext(DbContextOptions<E_MailApplicationsManagerContext> options)
          : base(options)
        {
        }

        public DbSet<Email> Emails { get; set; }

        public DbSet<EmailAttachment> Attachments { get; set; }

        public DbSet<LoanApplicant> LoanApplicants { get; set; }

        public DbSet<ReceivedEmail> ReceivedEmails { get; set; }

        public DbSet<RoleUser> RoleUsers { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UserRole();
            base.OnModelCreating(modelBuilder);
        }

    }
}
