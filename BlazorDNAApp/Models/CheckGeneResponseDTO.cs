using Newtonsoft.Json;

namespace BlazorDNAApp.Models
{
    public class CheckGeneResponseDTO
    {
        [JsonProperty]
        public JobGene Job { get; set; }

        public string Code { get; set; }


        // Problema resolvido com LCS longest common substring.  
        public static bool CheckGene(string gene, string dna)
        {
            int[,] dp = new int[gene.Length + 1, dna.Length + 1];
            int result = 0;

            for (int i = 1; i <= gene.Length; i++)
            {
                for (int j = 1; j <= dna.Length; j++)
                {
                    if (gene[i - 1] == dna[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                        result = Math.Max(result, dp[i, j]);
                    }
                }
            }
            return result > gene.Length/2.0;
        }

    }
}
