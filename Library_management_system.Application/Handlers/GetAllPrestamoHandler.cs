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
    public class GetAllPrestamoHandler:IRequestHandler<GetAllPrestamoQuery, List<PrestamoEntity>>
    {
        private readonly IPrestamoRepository _prestamoRepository;
        public GetAllPrestamoHandler(IPrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }
        public async Task<List<PrestamoEntity>> Handle(GetAllPrestamoQuery request, CancellationToken cancellationToken)
        {
            var repository = await _prestamoRepository.GetAllPrestamo();
            //var response = _mapper.Map<List<PrestamoEntity>>(repository);
            return repository;
        }
    }
}
