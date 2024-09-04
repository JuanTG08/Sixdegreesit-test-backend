using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace AccesoDatos
{
    // Clase base que proporciona métodos genéricos para interactuar con la base de datos usando Dapper
    public class AccesoDatosDapper
    {
        public string Conexion = String.Empty;

        // Método genérico que ejecuta una consulta SQL y devuelve una lista de resultados
        public List<Tresponse> ListQuery<Tresponse>(string sqlQuery, object parameters = null)
        {
            using (IDbConnection db = new SqlConnection(Conexion))
            {
                // Ejecuta la consulta usando Dapper y devuelve los resultados como una lista
                return db.Query<Tresponse>(sqlQuery, parameters, commandType: CommandType.Text).ToList();
            }
        }
    }
}
