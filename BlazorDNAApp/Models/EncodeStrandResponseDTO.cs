using Newtonsoft.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace BlazorDNAApp.Models
{
    public class EncodeStrandResponseDTO
    {
        [JsonProperty]
        public JobStrand Job { get; set; }

        public string Code { get; set; }

        public static string EncodeToBinary(string strand)
        {
            var binary = new StringBuilder();
            foreach (var c in strand)
            {
                switch (c)
                {
                    case 'A':
                        binary.Append("00");
                        break;
                    case 'C':
                        binary.Append("01");
                        break;
                    case 'T':
                        binary.Append("11");
                        break;
                    case 'G':
                        binary.Append("10");
                        break;
                    default:
                        throw new ArgumentException("Invalid nucleobase character in strand.");
                }
            }
            var bytes = Enumerable.Range(0, binary.Length / 8).Select(i => Convert.ToByte(binary.ToString().Substring(i * 8, 8), 2)).ToArray();
            return Convert.ToBase64String(bytes);
        }
    }
}
