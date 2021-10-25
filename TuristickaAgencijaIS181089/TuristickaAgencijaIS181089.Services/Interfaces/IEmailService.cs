
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencijaIS181089.Domain.DomainModels;

namespace TuristickaAgencijaIS181089.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<EmailMessage> allMails);
    }
}
