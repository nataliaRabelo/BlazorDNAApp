using Newtonsoft.Json;

namespace BlazorDNAApp.Models
{
    public class DecodeStrandResponseDTO
    {
        [JsonProperty]
        public JobStrandEncoded Job { get; set; }

        public string Code { get; set; }

        public static string DecodeBinaryToString(byte[] binary)
        {
            string decodedString = "";
            for (int i = 0; i < binary.Length; i++)
            {
                byte b = binary[i];
                for (int j = 0; j < 8; j += 2)
                {
                    // Extrair os bits de cada nucleotídeo
                    int nucleobase = (b >> (6 - j)) & 0b11;
                    // Converter os bits em caracteres
                    char c = ' ';
                    switch (nucleobase)
                    {
                        case 0b00:
                            c = 'A';
                            break;
                        case 0b01:
                            c = 'C';
                            break;
                        case 0b10:
                            c = 'G';
                            break;
                        case 0b11:
                            c = 'T';
                            break;
                    }
                    decodedString += c;
                }
            }
            return decodedString;
        }
    }
}
