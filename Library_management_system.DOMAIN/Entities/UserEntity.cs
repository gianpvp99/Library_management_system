using Library_management_system.DOMAIN.ValueObjects.UserEntity;

namespace Library_management_system.DOMAIN.Entities
{
    public sealed class User
    {
        public int? IdUsuario { get; private set; }
        public string? Usuario { get; private set; }
        public string? Clave { get; private set; }
        public string? Nombres { get; private set; }
        public string? ApellidoPaterno { get; private set; }
        public string? ApellidoMaterno { get; private set; }
        public string? NroDocumento { get; private set; }
        public string? Correo { get; private set; }
        public string? Telefono { get; private set; }

        public DireccionValueObject Direccion { get; private set; }
        public string? Ubigeo { get; private set; }

        public bool? Activo { get; private set; }
        public bool? Eliminado { get; private set; }
        public DateTime? FechaCreacion { get; private set; }
        public DateTime? FechaModificacion { get; private set; }
        public DateTime? FechaUltimoLogin { get; private set; }
        public int? IdBibliotecarioModificacion { get; private set; }

        public User(int? idUsuario, string? usuario, string? clave, string? nombres, string? apellidoPaterno, string? apellidoMaterno, string? nroDocumento, string? correo, string? telefono, DireccionValueObject direccion, string? ubigeo, bool? activo, bool? eliminado, DateTime? fechaCreacion, DateTime? fechaModificacion, DateTime? fechaUltimoLogin, int? idBibliotecarioModificacion)
        {
            IdUsuario = idUsuario;
            Usuario = usuario;
            Clave = clave;
            Nombres = nombres;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            NroDocumento = nroDocumento;
            Correo = correo;
            Telefono = telefono;
            Direccion = direccion;
            Ubigeo = ubigeo;
            Activo = activo;
            Eliminado = eliminado;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
            FechaUltimoLogin = fechaUltimoLogin;
            IdBibliotecarioModificacion = idBibliotecarioModificacion;
        }

        public static List<User> GetAllUsers()
        {
            return new List<User>();
        }
    }
}
