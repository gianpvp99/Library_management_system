using Library_management_system.DOMAIN.ValueObjects.BibliotecarioEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system.DOMAIN.Entities
{
    public sealed class BibliotecarioEntity
    {
        public int? IdBibliotecario {  get; private set; }
        public string NombresApellidos {  get; private set; }
        public UsuarioValueObject Usuario { get; private set; }
        public string? Clave {  get; private set; }
        public bool? Activo { get; private set; }
        public bool? Eliminado {  get; private set; }
        public DateTime? FechaCreacion {  get; private set; }
        public DateTime? FechaModificacion {  get; private set; }
        public DateTime? FechaUltimoLogin {  get; private set; }
        public int? IdBibliotecarioModificacion { get; private set; }

        public BibliotecarioEntity(int? idBibliotecario, string nombresApellidos, UsuarioValueObject usuario, string? clave, bool? activo, bool? eliminado, DateTime? fechaCreacion, DateTime? fechaModificacion, DateTime? fechaUltimoLogin, int? idBibliotecarioModificacion)
        {
            IdBibliotecario = idBibliotecario;
            NombresApellidos = nombresApellidos;
            Usuario = usuario;
            Clave = clave;
            Activo = activo;
            Eliminado = eliminado;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            FechaUltimoLogin = fechaUltimoLogin;
            IdBibliotecarioModificacion = idBibliotecarioModificacion;
        }
    }
}
