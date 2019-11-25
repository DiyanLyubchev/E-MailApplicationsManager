using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;

namespace E_MailApplicationsManager.Service.Util
{
    public static class ValidatorEmailService
    {
        public static void ValidatorAddMailIfDtoIsNull(EmailDto emailDto)
        {
            if (emailDto.DateReceived == null ||
            emailDto.Sender == null || emailDto.Subject == null)
            {
                throw new EmailExeption("Email does not exist!");
            }
        }
        public static void ValidatorGmailIdLength(EmailDto emailDto)
        {
            if (emailDto.GmailId.Length < 5 || emailDto.GmailId.Length > 100)
            {
                throw new EmailExeption("Lenght of GmailId is not correct!");
            }
        }
        public static void ValidatorSubjectLength(EmailDto emailDto)
        {
            if (emailDto.Subject.Length < 3 || emailDto.Subject.Length > 100)
            {
                throw new EmailExeption("Lenght of Subject is not correct!");
            }
        }
        public static void ValidatorSenderLength(EmailDto emailDto)
        {
            if (emailDto.Sender.Length < 5 || emailDto.Sender.Length > 50)
            {
                throw new EmailExeption("Lenght of Sender is not correct!");
            }
        }

        public static void ValidatorChangeStatus(EmailStatusIdDto emailStatusId)
        {
            if (emailStatusId.StatusId == null || emailStatusId.GmailId == null)
            {
                throw new EmailExeption("Status id or Gmail id cannot be null");
            }
        }

        public static void ValidatorAddAttachment(EmailAttachmentDTO attachmentDTO)
        {
            if (attachmentDTO.FileName.Length < 5 || attachmentDTO.FileName.Length > 100)
            {
                throw new EmailExeption("Lenght of name attachment is not correct!");
            }

            if (attachmentDTO.GmailId.Length < 5 || attachmentDTO.GmailId.Length > 100)
            {
                throw new EmailExeption("Lenght of GmailId is not correct!");
            }

        }
        public static void ValidatorAddBodyToCurrentEmailIfDtoBodyIsNull(EmailContentDto emailDto)
        {
            if (emailDto.Body == null)
            {
                throw new EmailExeption($"Email with the following id {emailDto.GmailId} does not exist");
            }

        }

        public static void ValidatorAddBodyToCurrentEmailBodyLength(EmailContentDto emailDto)
        {
            if (emailDto.Body.Length > 1000)
            {
                throw new EmailExeption($"Body of email is to long!");
            }
        }
        public static void ValidatorAddBodyToCurrentEmailExistBody(Email email , EmailContentDto emailDto)
        {
            if (email.Body != null)
            {
                throw new EmailExeption($"Email with the following id {emailDto.GmailId} contains body");
            }
        }

        public static void ValidatorCheckEmailBody(Email email)
        {
            if (email.Body == null)
            {
                throw new EmailExeption("Email body is empty");
            }
        }

        public static void ValidatorSetEmailStatusInvalidApplication(string dto)
        {
            if (dto == null)
            {
                throw new EmailExeption($"Email with the following id {dto} does not exist!");
            }
        }

    }
}
