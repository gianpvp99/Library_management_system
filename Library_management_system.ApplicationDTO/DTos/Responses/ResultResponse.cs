using Library_management_system.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.DOMAIN.DTos.Responses
{
    public class ResultResponse<T>
    {
        public string? Mensaje { get; set; }
        public bool? Estado { get; set; }
        public bool? Error { get; set; }
        public T Data { get; set; }
    }
}
