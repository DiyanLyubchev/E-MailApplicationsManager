﻿using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Service;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.EmailTest
{
    [TestClass]
    public class EmailAttachment_Should
    {
        [TestMethod]
        public async Task AddAttachment_Test()
        {
            var gmailId = "TestGmailId";
            var FileName = "TestFileName";
            double fileSize = 876.77;

            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;
            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(AddAttachment_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.EmailAttachments.AddAsync(
                    new EmailAttachment
                    {
                        GmailId = gmailId,
                        FileName = FileName,
                        SizeInKB = fileSize
                    });
                await actContext.SaveChangesAsync();

                var ettachmentDto = new EmailAttachmentDTO
                {
                    FileName = FileName,
                    GmailId = gmailId,
                    SizeInKB = fileSize
                };

                var sut = new EmailService(actContext, loggerMock, encodeDecodeServiceMock);
                var result = sut.AddAttachmentAsync(ettachmentDto);

                Assert.IsNotNull(result);
            }
            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                Assert.AreEqual(2,assertContext.EmailAttachments.Count());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenAddAttachmentNameIsMaxLenght_Test()
        {
            var gmailId = "TestGmailId";
            var FileName = new String('T',101);
            double fileSize = 876.77;

            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;
            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenAddAttachmentNameIsMaxLenght_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var ettachmentDto = new EmailAttachmentDTO
                {
                    FileName = FileName,
                    GmailId = gmailId,
                    SizeInKB = fileSize
                };

                var sut = new EmailService(actContext, loggerMock, encodeDecodeServiceMock);
                await sut.AddAttachmentAsync(ettachmentDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenAddAttachmentNameIsMinLenght_Test()
        {
            var gmailId = "TestGmailId";
            var FileName = "Test";
            double fileSize = 876.77;

            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;
            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenAddAttachmentNameIsMinLenght_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var ettachmentDto = new EmailAttachmentDTO
                {
                    FileName = FileName,
                    GmailId = gmailId,
                    SizeInKB = fileSize
                };

                var sut = new EmailService(actContext, loggerMock, encodeDecodeServiceMock);
                await sut.AddAttachmentAsync(ettachmentDto);

            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenGmailIdIsWIthMaxLenght_AddAttachment_Test()
        {
            var gmailId = new String('T', 101);
            var FileName = "TestName";
            double fileSize = 876.77;

            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;
            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenGmailIdIsWIthMaxLenght_AddAttachment_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var ettachmentDto = new EmailAttachmentDTO
                {
                    FileName = FileName,
                    GmailId = gmailId,
                    SizeInKB = fileSize
                };

                var sut = new EmailService(actContext, loggerMock, encodeDecodeServiceMock);
                await sut.AddAttachmentAsync(ettachmentDto);

            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenGmailIdIsWIthMinLenght_AddAttachment_Test()
        {
            var gmailId = "Test";
            var FileName = "TestName";
            double fileSize = 876.77;

            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;
            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenGmailIdIsWIthMinLenght_AddAttachment_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var ettachmentDto = new EmailAttachmentDTO
                {
                    FileName = FileName,
                    GmailId = gmailId,
                    SizeInKB = fileSize
                };

                var sut = new EmailService(actContext, loggerMock, encodeDecodeServiceMock);
                await sut.AddAttachmentAsync(ettachmentDto);

            }
        }
    }
}
