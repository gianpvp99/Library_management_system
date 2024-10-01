using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Application.DTOs.Responses
{
    public class ResultResponse<T>
    {
        public T? Data { get; set; }
        public bool? Error { get; set; }
        public bool? Estado { get; set; }
        public string? Mensaje { get; set; }
    }
}
