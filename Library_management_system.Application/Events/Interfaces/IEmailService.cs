using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Application.Events.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string from, string subject, string body);
    }
}
