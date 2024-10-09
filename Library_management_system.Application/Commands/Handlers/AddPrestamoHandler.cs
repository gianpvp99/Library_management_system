using AutoMapper;
using Library_management_system.Application.Commands;
using Library_management_system.Application.DTOs;
using Library_management_system.Application.DTOs.Responses;
using Library_management_system.Application.Events;
using Library_management_system.Application.Querys;
using Library_management_system.DOMAIN.Entities;
using Library_management_system.DOMAIN.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Application.Commands.Handlers
{
    public class AddPrestamoHandler : IRequestHandler<AddPrestamoCommand, ResultResponse<AddPrestamoResponse>>
    {
        private readonly IPrestamoRepository _prestamoRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AddPrestamoHandler(IPrestamoRepository prestamoRepository, IMapper mapper, IMediator mediator)
        {
            _prestamoRepository = prestamoRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResultResponse<AddPrestamoResponse>> Handle(AddPrestamoCommand request, CancellationToken cancellationToken)
        {
            var mapperDTO = _mapper.Map<PrestamoEntity>(request);
            await _prestamoRepository.AddPrestamo(mapperDTO);
            var response = ResultResponse<AddPrestamoResponse>.Success(new AddPrestamoResponse(), "Registro Exitoso");
            await _mediator.Publish(new AddPrestamoEvent("gianpvp99@gmail.com","Prestamo registrado","Hola mundo / body"), cancellationToken);
            return response;

        }
    }
}
