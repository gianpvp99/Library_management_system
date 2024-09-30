using Library_management_system.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Application.DTos.Responses
{
    public class AddPrestamoResponse
    {
        public string? Mensaje { get; set; }
        public string? Estado {  get; set; }
        public bool? Error { get; set; }
        public List<PrestamoEntity>? Data {  get; set; }
    }
}
