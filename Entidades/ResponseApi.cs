namespace Entidades
{
    // Clase genérica para estandarizar las respuestas API
    public class ResponseApi<T>
    {
        public CodeStatus Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public ResponseApi(CodeStatus code, string message, T? data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        public ResponseApi(CodeStatus code, string message)
        {
            Code = code;
            Message = message;
            Data = default;
        }
    }
    // Enum para los códigos de estado de la respuesta
    public enum CodeStatus
    {
        Ok = 200,
        BadRequest = 400,
        NotFound = 404
    }
}
