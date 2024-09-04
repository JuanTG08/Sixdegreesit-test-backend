using Entidades;

namespace BackendApi.Servicios.Usuarios
{
    // Define un contrato para el servicio de usuario, lo que hace que el código sea más fácil de mantener y probar
    public interface IServicioUsuario
    {
        // Método para obtener la lista de usuarios
        public List<EntidadUsuario> ListaUsuarios();
    }
}
