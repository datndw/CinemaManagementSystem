using CinemaManagementSystem.Application.Contracts.Infrastructure;
using CinemaManagementSystem.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _settings { get; }
        public EmailSender(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }
        public Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_settings.ApiKey);
            throw new NotImplementedException();
        }
    }
}
