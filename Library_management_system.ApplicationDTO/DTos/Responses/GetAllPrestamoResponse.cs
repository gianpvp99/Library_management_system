using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.DOMAIN.DTos.Responses
{
    public class GetAllPrestamoResponse
    {
        public int? IdPrestamo { get; set; }
        public int? IdBibliotecario { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdLibro { get; set; }
        public string? Titulo { get; set; }
        public string? Categoria {  get; set; }
        public string? Autor {  get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolvucion { get; set; }
        public string? Estado { get; set; }
        public bool? Eliminado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? IdBibliotecarioModificacion { get; set; }
    }
}
