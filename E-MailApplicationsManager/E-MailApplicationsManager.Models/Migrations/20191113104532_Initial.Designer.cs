﻿// <auto-generated />
using System;
using E_MailApplicationsManager.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_MailApplicationsManager.Models.Migrations
{
    [DbContext(typeof(E_MailApplicationsManagerContext))]
    [Migration("20191113104532_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E_MailApplicationsManager.Models.Model.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmailId");

                    b.Property<string>("InfoLog");

                    b.Property<string>("InfoLogOut");

                    b.Property<string>("LastStatusInfo");

                    b.Property<string>("NewStatusInfo");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EmailId");

                    b.HasIndex("UserId");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.Model.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<string>("DateReceived");

                    b.Property<int>("EmailStatusId");

                    b.Property<string>("GmailId");

                    b.Property<DateTime?>("InitialRegistrationInData");

                    b.Property<bool>("IsSeen");

                    b.Property<string>("Sender");

                    b.Property<DateTime?>("SetCurrentStatus");

                    b.Property<DateTime?>("SetTerminalState");

                    b.Property<string>("Subject");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EmailStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.Model.EmailAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmailId");

                    b.Property<string>("FileName");

                    b.Property<string>("GmailId");

                    b.Property<double?>("SizeInKB");

                    b.HasKey("Id");

                    b.HasIndex("EmailId");

                    b.ToTable("EmailAttachments");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.Model.EmailStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Not Reviewed"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Invalid Application"
                        },
                        new
                        {
                            Id = 3,
                            Status = "New"
                        },
                        new
                        {
                            Id = 4,
                            Status = "Open"
                        },
                        new
                        {
                            Id = 5,
                            Status = "Closed"
                        });
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.Model.LoanApplicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EGN");

                    b.Property<int?>("EmailId");

                    b.Property<string>("GmailId");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EmailId")
                        .IsUnique()
                        .HasFilter("[EmailId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("LoanApplicants");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("FirstLog");

                    b.Property<DateTime?>("LastLog");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "c23c3678-6194-4b7e-a928-09614190eb62",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b517b337-c6ca-4163-b7d1-8229cd299d13",
                            Email = "admin1@admin.com",
                            EmailConfirmed = false,
                            FirstLog = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN1@ADMIN.COM",
                            NormalizedUserName = "DIYAN",
                            PasswordHash = "AQAAAAEAACcQAAAAEHI5CjQ/0ekKR9yCWOib1gTC+FMhi3PQZnEHxOak4qhrMK5aNCrXyl+CJ61sTcGttw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN",
                            TwoFactorEnabled = false,
                            UserName = "Diyan"
                        },
                        new
                        {
                            Id = "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "169b560a-6175-4c54-9bf2-df695f5a9294",
                            Email = "admin2@admin.com",
                            EmailConfirmed = false,
                            FirstLog = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN2@ADMIN.COM",
                            NormalizedUserName = "BOBI",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ6zNxUwPgAT8CJ27LxhpSsBr6hIotCTHV3aqM09V6VqUQIkTm2lA3J1gbTIctt4AQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "74CLJEIXNYLPRXMVXXNSWXZH6R6KJRRU",
                            TwoFactorEnabled = false,
                            UserName = "Bobi"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "c23c3678-6194-4b7e-a928-09614190eb62",
                            RoleId = "ca678235-7571-4177-984f-e9d1957b0187"
                        },
                        new
                        {
                            UserId = "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                            RoleId = "ca678235-7571-4177-984f-e9d1957b0187"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.Model.RoleUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("RoleUser");

                    b.HasData(
                        new
                        {
                            Id = "ca678235-7571-4177-984f-e9d1957b0187",
                            ConcurrencyStamp = "84480876-e309-449a-92af-5ea33074ba83",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                            ConcurrencyStamp = "29fce371-9d0e-4ba6-9ed8-30a7876caae2",
                            Name = "Operator",
                            NormalizedName = "OPERATOR"
                        });
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.Model.AuditLog", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.Model.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("E_MailApplicationsManager.Models.Model.User", "User")
                        .WithMany("AuditLogs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.Model.Email", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.Model.EmailStatus", "Status")
                        .WithMany("Emails")
                        .HasForeignKey("EmailStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("E_MailApplicationsManager.Models.Model.User", "User")
                        .WithMany("Emails")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.Model.EmailAttachment", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.Model.Email", "Email")
                        .WithMany("EmailAttachments")
                        .HasForeignKey("EmailId");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.Model.LoanApplicant", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.Model.Email", "Emails")
                        .WithOne("LoanApplicant")
                        .HasForeignKey("E_MailApplicationsManager.Models.Model.LoanApplicant", "EmailId");

                    b.HasOne("E_MailApplicationsManager.Models.Model.User", "User")
                        .WithMany("LoanApplicant")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("E_MailApplicationsManager.Models.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.Model.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}