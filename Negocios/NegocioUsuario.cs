using AccesoDatos;
using Entidades;
namespace Negocios
{
    // Clase que maneja la lógica de negocio relacionada con los usuarios
    public class NegocioUsuario
    {
        private AccesoDatosUsuarios AccesoDatos;

        // Constructor que recibe la cadena de conexión para inicializar la clase de acceso a datos
        public NegocioUsuario(string cadenaConexion)
        {
            AccesoDatos = new AccesoDatosUsuarios(cadenaConexion);
        }


        // Método que devuelve una lista de usuarios desde la capa de acceso a datos
        public List<EntidadUsuario> ListUsuarios()
        {
            try
            {
                return AccesoDatos.ListaUsuarios();
            } catch (Exception ex) {
                // Manejo de errores: se registra el mensaje y se vuelve a lanzar la excepción
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
