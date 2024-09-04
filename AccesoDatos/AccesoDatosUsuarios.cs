using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    // Clase que hereda de AccesoDatosDapper y maneja la interacción con la tabla 'Usuario'
    public class AccesoDatosUsuarios : AccesoDatosDapper
    {
        // Establecemos a "NombreTabla" el nombre de la tabla correspondiente
        public string NombreTabla = "Usuario";
        // Establecemos los campos de la tabla
        public string CampoUsuId = "usuID";
        public string CampoNombre = "nombre";
        public string CampoApellido = "apellido";

        // Constructor que establece la cadena de conexión heredada de AccesoDatosDapper
        public AccesoDatosUsuarios(string cadenaConexion) 
        {
            // Establecemos la cadena de conexión
            Conexion = cadenaConexion;
        }

        // Método que devuelve una lista de usuarios ejecutando una consulta SQL
        public List<EntidadUsuario> ListaUsuarios()
        {
            // Ejecutamos el query para obtener los datos
            return ListQuery<EntidadUsuario>($"SELECT {CampoUsuId}, {CampoNombre}, {CampoApellido} FROM {NombreTabla}");
        }
    }
}
