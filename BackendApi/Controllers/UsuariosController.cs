using BackendApi.Servicios.Usuarios;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        // Inyección del servicio de usuario, permite desacoplar la lógica de negocio
        private readonly IServicioUsuario _servicioUsuario;
        // El controlador recibe una instancia de IServicioUsuario a través de la inyección de dependencias
        public UsuariosController(IServicioUsuario servicioUsuario)
        {
            _servicioUsuario = servicioUsuario;
        }
        // Maneja solicitudes GET a /Usuarios
        [HttpGet]
        public ActionResult ListUsuarios()
        {
            try
            {
                // Obtiene la lista de usuarios utilizando el servicio de usuario
                List<EntidadUsuario> Usuarios = _servicioUsuario.ListaUsuarios();
                // Devuelve la lista de usuarios en un formato estándar usando ResponseApi
                return Ok(new ResponseApi<List<EntidadUsuario>>(CodeStatus.Ok, "Listado de usuarios", Usuarios));
            } catch (Exception ex)
            {
                // Si ocurre una excepción, se registra el mensaje en la consola
                Console.WriteLine(ex.ToString());
                // Manejo básico de errores: devuelve un BadRequest con un mensaje genérico
                return BadRequest(new ResponseApi<string>(CodeStatus.Ok, "No hay datos"));
            }
        }
    }
}
