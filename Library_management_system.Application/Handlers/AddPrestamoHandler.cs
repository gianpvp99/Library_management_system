using AutoMapper;
using Library_management_system.Application.Commands;
using Library_management_system.Application.DTos.Responses;
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
    public class AddPrestamoHandler:IRequestHandler<AddPrestamoCommand, AddPrestamoResponse>
    {
        private readonly IPrestamoRepository _prestamoRepository;
        //private readonly IMapper _mapper;
        public AddPrestamoHandler(IPrestamoRepository prestamoRepository/*, IMapper mapper*/)
        {
            _prestamoRepository = prestamoRepository;
            //_mapper = mapper;
        }

        public async Task<AddPrestamoResponse> Handle(AddPrestamoCommand request, CancellationToken cancellationToken)
        {
            //var dto = _mapper.Map<PrestamoEntity>(request);
            var PrestamoEntity = new PrestamoEntity() { 
                IdPrestamo = request.IdPrestamo,
                IdBibliotecario = request.IdPrestamo,
                IdUsuario = request.IdUsuario,
                IdLibro = request.IdLibro,
                FechaPrestamo = request.FechaPrestamo,
                FechaDevolvucion = request.FechaDevolvucion,
                Estado = request.Estado,
                Eliminado = request.Eliminado,
                FechaCreacion = request.FechaCreacion,
                FechaModificacion = request.FechaModificacion,
                IdBibliotecarioModificacion = request.IdBibliotecarioModificacion};
            var repository = await _prestamoRepository.AddPrestamo(PrestamoEntity);
            //var response = _mapper.Map<List<PrestamoEntity>>(repository);
            return repository;
        }
    }
}
