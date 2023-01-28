using Newtonsoft.Json;

namespace BlazorDNAApp.Models
{

    public class LoginResponseDTO
    {
        [JsonProperty]
        public string accessToken { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }

        public static string token;

    }
}
