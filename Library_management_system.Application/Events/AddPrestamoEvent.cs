using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Application.Events
{
    public class AddPrestamoEvent : INotification
    {
        public string Correo { get; set; }
        public string Subject {  get; set; }
        public string Body { get; set; }

        public AddPrestamoEvent(string correo, string subject, string body)
        {
            Correo = correo;
            Subject = subject;
            Body = body;
        }
    }
}
