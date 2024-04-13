namespace rpgapi.Models
{
    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
            
        }
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = String.Empty;

    }
}
