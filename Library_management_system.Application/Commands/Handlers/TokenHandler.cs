using Library_management_system.Application.DTOs.Responses;
using Library_management_system.DOMAIN.Interfaces;
using Library_management_system.DTO.DTOs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Application.Commands.Handlers
{
    public class TokenHandler : IRequestHandler<TokenCommand, ResultResponse<TokenResponse>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public TokenHandler(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<ResultResponse<TokenResponse>> Handle(TokenCommand request, CancellationToken cancellationToken)
        {
            var token = _jwtTokenGenerator.GenerateToken(request.IdUsuario, request.Correo);
            return ResultResponse<TokenResponse>.Success(new TokenResponse(token,"Refresh",DateTime.Now), "Token generado");
        }
    }
}
