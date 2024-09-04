using Entidades;
using Negocios;
namespace BackendApi.Servicios.Usuarios
{
    // Clase que implementa la interfaz IServicioUsuario, encargada de gestionar la lógica de usuarios
    public class ServicioUsuarios : IServicioUsuario
    {
        // Dependencia de NegocioUsuario, que maneja la lógica de negocio relacionada con los usuarios
        private readonly NegocioUsuario _negocioUsuario;

        // Constructor que recibe una instancia de IConfiguration para obtener la cadena de conexión
        public ServicioUsuarios(IConfiguration configuration)
        {
            // Se crea una instancia de NegocioUsuario usando la cadena de conexión obtenida de la configuración
            _negocioUsuario = new NegocioUsuario(configuration.GetConnectionString("DefaultConnection"));
        }

        // Método que obtiene la lista de usuarios usando la capa de negocio
        public List<EntidadUsuario> ListaUsuarios()
        {
            try
            {
                // Llama al método ListUsuarios del objeto de negocio para obtener la lista de usuarios
                List<EntidadUsuario> Usuarios = _negocioUsuario.ListUsuarios();
                return Usuarios; // Retorna la lista de usuarios
            } catch (Exception ex)
            {
                // Si ocurre una excepción, se registra el mensaje en la consola
                Console.WriteLine(ex.Message);
                // Lanza una nueva excepción genérica para que el error se propague
                throw new Exception();
            }
        }
    }
}
