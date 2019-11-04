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

        public DbSet<EmailAttachment> EmailAttachments { get; set; }

        public DbSet<LoanApplicant> LoanApplicants { get; set; }

        public DbSet<EmailStatus> Statuses { get; set; }

        public DbSet<RoleUser> RoleUsers { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailAttachment>().HasKey(key => key.Id);
            modelBuilder.Entity<EmailAttachment>()
                .HasOne(email => email.Email)
                .WithMany(attachment => attachment.EmailAttachments)
                .HasForeignKey(id => id.EmailId);

            modelBuilder.SeedUserRoles();
            modelBuilder.SeedStatuses();
            base.OnModelCreating(modelBuilder);
        }


    }
}
