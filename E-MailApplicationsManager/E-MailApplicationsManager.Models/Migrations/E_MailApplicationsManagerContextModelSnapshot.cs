﻿// <auto-generated />
using System;
using E_MailApplicationsManager.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_MailApplicationsManager.Models.Migrations
{
    [DbContext(typeof(E_MailApplicationsManagerContext))]
    partial class E_MailApplicationsManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E_MailApplicationsManager.Models.AuditLog", b =>
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

            modelBuilder.Entity("E_MailApplicationsManager.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<string>("DateReceived");

                    b.Property<DateTime?>("InitialRegistrationInData");

                    b.Property<bool>("IsSeen");

                    b.Property<string>("Sender");

                    b.Property<DateTime>("SetCurrentStatus");

                    b.Property<DateTime?>("SetTerminalState");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.EmailAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmailId");

                    b.Property<string>("FileName");

                    b.Property<double?>("SizeInMb");

                    b.HasKey("Id");

                    b.HasIndex("EmailId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.LoanApplicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EGN");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LoanApplicants");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.ReceivedEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmailId");

                    b.Property<int>("Status");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EmailId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("ReceivedEmails");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.User", b =>
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
                            ConcurrencyStamp = "b4ef66af-cc76-450d-961f-6eb5c6b446a8",
                            Email = "admin1@admin.com",
                            EmailConfirmed = false,
                            FirstLog = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN1@ADMIN.COM",
                            NormalizedUserName = "DIYAN",
                            PasswordHash = "AQAAAAEAACcQAAAAEJJ2pyQHKYoFqSlBFrZg/i6JK5kjOqkNPyicPmn44nIEFsBPARoiQ1RqihTsPILn3g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN",
                            TwoFactorEnabled = false,
                            UserName = "Diyan"
                        },
                        new
                        {
                            Id = "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8ca424c7-acc4-4578-9c7d-ab584b7f95d3",
                            Email = "admin2@admin.com",
                            EmailConfirmed = false,
                            FirstLog = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN2@ADMIN.COM",
                            NormalizedUserName = "BOBI",
                            PasswordHash = "AQAAAAEAACcQAAAAEKmCnqyRj9yope/tBa/6TQ2pwavOF/14bTo9alDp23sD60Aw309iHP2YMuggTTkgjA==",
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
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

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

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.RoleUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("RoleUser");

                    b.HasData(
                        new
                        {
                            Id = "ca678235-7571-4177-984f-e9d1957b0187",
                            ConcurrencyStamp = "2d9f5830-fd91-42b9-b753-4c89fa475115",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "ef1c4fa2-0b76-4598-aaee-c6e02803d486",
                            ConcurrencyStamp = "6a5b11f3-3169-4be4-a6f0-b5a23032ab02",
                            Name = "Operator",
                            NormalizedName = "OPERATOR"
                        });
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.AuditLog", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("E_MailApplicationsManager.Models.User", "User")
                        .WithMany("AuditLogs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.EmailAttachment", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.Email", "Email")
                        .WithMany("EmailAttachments")
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.LoanApplicant", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.User")
                        .WithMany("LoanApplicant")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("E_MailApplicationsManager.Models.ReceivedEmail", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.Email", "Email")
                        .WithOne("ReceivedEmail")
                        .HasForeignKey("E_MailApplicationsManager.Models.ReceivedEmail", "EmailId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("E_MailApplicationsManager.Models.User", "User")
                        .WithMany()
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
                    b.HasOne("E_MailApplicationsManager.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.User")
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

                    b.HasOne("E_MailApplicationsManager.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("E_MailApplicationsManager.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
