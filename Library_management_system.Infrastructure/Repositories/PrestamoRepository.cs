using Library_management_system.Application.DTOs.Responses;
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

        public async Task AddPrestamo(PrestamoEntity data)
        {
            data.FechaCreacion = DateTime.Now;
            data.Estado = "Aprobado";
            data.Eliminado = false;
            await _dbContext.Prestamos.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GetAllPrestamoResponse>> GetAllPrestamo()
        {
            var response = await (from p in _dbContext.Prestamos
                             join l in _dbContext.Libros
                             on p.IdLibro equals l.IdLibro
                             select new GetAllPrestamoResponse()
                             { 
                                 IdPrestamo = p.IdPrestamo,
                                 IdBibliotecario = p.IdBibliotecarioModificacion,
                                 IdUsuario = p.IdUsuario,
                                 IdLibro = p.IdLibro,
                                 Titulo = l.Titulo,
                                 Categoria = l.Categoria,
                                 Autor = l.Autor,
                                 FechaPrestamo = p.FechaPrestamo,
                                 FechaDevolvucion = p.FechaDevolvucion,
                                 Estado = p.Estado,
                                 Eliminado = p.Eliminado,
                                 FechaCreacion = p.FechaCreacion,
                                 FechaModificacion = p.FechaModificacion,
                                 IdBibliotecarioModificacion = p.IdBibliotecarioModificacion
                             }).ToListAsync();
            return response;
        }
    }
}
