﻿using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

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

                var sut = new EmailService(actContext, mockEncodeDecodeService);
                var result = sut.AddAttachmentAsync(ettachmentDto);

                Assert.IsNotNull(result);
            }
            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                Assert.AreEqual(2,assertContext.EmailAttachments.Count());
            }
        }
    }
}