using Library_management_system.Application.DTos.Responses;
using Library_management_system.DOMAIN.Entities;
using Library_management_system.DOMAIN.Interfaces;
using Library_management_system.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.Infrastructure.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PrestamoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddPrestamoResponse> AddPrestamo(PrestamoEntity data)
        {
            var addPrestamo = _dbContext.Prestamos.Add(data);
            _dbContext.SaveChanges();
            var response = new AddPrestamoResponse() {Error = false, Mensaje = "Registro exitoso", Estado = "Registrado"};
            return response;
        }

        public async Task<List<PrestamoEntity>> GetAllPrestamo()
        {
            var response = await _dbContext.Prestamos.ToListAsync();
            return response;
        }
    }
}
