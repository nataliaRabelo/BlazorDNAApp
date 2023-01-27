using Newtonsoft.Json;

namespace BlazorDNAApp.Models
{
    public class ResponseDTO
    {
        [JsonProperty]
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
