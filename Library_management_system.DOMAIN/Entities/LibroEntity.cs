using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.DOMAIN.Entities
{
    public sealed class LibroEntity
    {
        public int? IdLibro { get; private set; }
        public int? IdBibliotecario { get; private set; }
        public string? Titulo { get; private set; }
        public string? Autor {  get; private set; }
        public string? Categoria { get; private set; }
        public string? Estado { get; private set; }
        public bool? Eliminado {  get; private set; }
        public DateTime? FechaCreacion { get; private set; }
        public DateTime? FechaModificacion {  get; private set; }
        public int? IdBibliotecarioModificacion { get; private set; }

        public LibroEntity(int? idLibro, int? idBibliotecario, string? titulo, string? autor, string? categoria, string? estado, bool? eliminado, DateTime? fechaCreacion, DateTime? fechaModificacion, int? idBibliotecarioModificacion)
        {
            IdLibro = idLibro;
            IdBibliotecario = idBibliotecario;
            Titulo = titulo;
            Autor = autor;
            Categoria = categoria;
            Estado = estado;
            Eliminado = eliminado;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            IdBibliotecarioModificacion = idBibliotecarioModificacion;
        }
    }
}
