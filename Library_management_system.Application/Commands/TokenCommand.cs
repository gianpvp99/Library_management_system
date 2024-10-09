using Library_management_system.Application.DTOs.Responses;
using Library_management_system.DTO.DTOs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Application.Commands
{
    public class TokenCommand:IRequest<ResultResponse<TokenResponse>>
    {
        public int IdUsuario{ get; set; }
        public string Correo { get; set; }
    }
}
