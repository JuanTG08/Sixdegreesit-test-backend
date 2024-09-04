namespace Entidades
{
    // Representa la entidad de un usuario en la base de datos
    public class EntidadUsuario
    {
        public decimal usuID { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
    }
}
