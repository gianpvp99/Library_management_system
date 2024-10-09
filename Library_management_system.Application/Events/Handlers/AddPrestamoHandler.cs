using Library_management_system.Application.Events.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Application.Events.Handlers
{
    public class AddPrestamoHandler: INotificationHandler<AddPrestamoEvent>
    {
        public readonly IEmailService _emailService;
        public AddPrestamoHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task Handle(AddPrestamoEvent notification, CancellationToken cancellationToken)
        {
            await _emailService.SendEmailAsync(notification.Correo, notification.Subject, notification.Body);
        }
    }
}
