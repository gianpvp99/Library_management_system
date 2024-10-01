using Library_management_system.Application.DTOs.Responses;
using Library_management_system.Application.Querys;
using Library_management_system.DOMAIN.Entities;
using Library_management_system.DOMAIN.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Application.Handlers
{
    public class GetAllPrestamoHandler:IRequestHandler<GetAllPrestamoQuery,ResultResponse<List<GetAllPrestamoResponse>>>
    {
        private readonly IPrestamoRepository _prestamoRepository;
        public GetAllPrestamoHandler(IPrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }
        public async Task<ResultResponse<List<GetAllPrestamoResponse>>> Handle(GetAllPrestamoQuery request, CancellationToken cancellationToken)
        {
            var repository = await _prestamoRepository.GetAllPrestamo();
            var response = new ResultResponse<List<GetAllPrestamoResponse>>() { Data = repository, Error = false, Estado = true, Mensaje = "Listado Exitoso" };
            //var response = _mapper.Map<List<PrestamoEntity>>(repository);
            return response;
        }
    }
}
