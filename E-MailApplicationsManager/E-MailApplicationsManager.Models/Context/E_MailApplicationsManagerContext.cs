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
            // EmailAttachment
            modelBuilder.Entity<EmailAttachment>()
                .HasKey(key => key.Id);

            modelBuilder.Entity<EmailAttachment>()
                .HasOne(email => email.Email)
                .WithMany(attachment => attachment.EmailAttachments)
                .HasForeignKey(id => id.EmailId);

            modelBuilder.Entity<EmailAttachment>()
                .Property(emailAttachment => emailAttachment.SizeInKB);


            modelBuilder.Entity<EmailAttachment>()
                 .Property(emailAttachment => emailAttachment.FileName);


            //Email
            modelBuilder.Entity<Email>()
               .HasKey(key => key.Id);

            modelBuilder.Entity<Email>()
               .HasOne(emailStatus => emailStatus.Status)
               .WithMany(email => email.Emails)
               .HasForeignKey(id => id.EmailStatusId);

            modelBuilder.Entity<Email>()
              .HasOne(user => user.User)
              .WithMany(email => email.Emails)
              .HasForeignKey(id => id.UserId);

            //LoanApplicant

            modelBuilder.Entity<LoanApplicant>()
             .HasOne(user => user.User)
             .WithMany(email => email.LoanApplicant)
             .HasForeignKey(id => id.UserId);

            modelBuilder.Entity<LoanApplicant>()
                .HasKey(key => key.Id);

            modelBuilder.SeedUserRoles();
            modelBuilder.SeedStatuses();
            base.OnModelCreating(modelBuilder);
        }


    }
}
