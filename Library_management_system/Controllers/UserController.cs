using Library_management_system.Application.Commands;
using Library_management_system.Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library_management_system.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        public UserController(IMediator mediator, JwtTokenGenerator jwtTokenGenerator)
        {
            _mediator = mediator;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {

                //var res = await _mediator.Send(request);
                var res = await _mediator.Send(new TokenCommand() { Correo = "gianpvp99@gmail.com", IdUsuario = 100});
                //var token = _jwtTokenGenerator.GenerateToken("1", "gianpvp99@gmail.com");

                return Ok(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
