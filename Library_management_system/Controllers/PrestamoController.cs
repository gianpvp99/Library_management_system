using AutoMapper;
using Library_management_system.Application.Commands;
using Library_management_system.Application.Handlers;
using Library_management_system.Application.Querys;
using Library_management_system.DOMAIN.Entities;
using Library_management_system.DOMAIN.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library_management_system.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrestamoController:ControllerBase
    {
        private readonly IMediator _mediator;
        public PrestamoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("GetAllPrestamo")]
        [HttpGet]
        public async Task<IActionResult> GetAllPrestamo()
        {
            try
            {
                var res = await _mediator.Send(new GetAllPrestamoQuery());
                
                return Ok(res);
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("AddPrestamo")]
        [HttpPost]
        public async Task<IActionResult> AddPrestamo(AddPrestamoCommand request)
        {
            try
            {
                var res = await _mediator.Send(request);

                return Ok(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
