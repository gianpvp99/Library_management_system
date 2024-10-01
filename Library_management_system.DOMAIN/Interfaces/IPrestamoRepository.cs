using Library_management_system.Application.DTOs.Responses;
using Library_management_system.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.DOMAIN.Interfaces
{
    public interface IPrestamoRepository
    {
        Task<List<GetAllPrestamoResponse>> GetAllPrestamo();
        Task AddPrestamo(PrestamoEntity data);
    }
}
