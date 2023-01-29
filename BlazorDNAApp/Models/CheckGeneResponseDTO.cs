using Newtonsoft.Json;

namespace BlazorDNAApp.Models
{
    public class CheckGeneResponseDTO
    {
        [JsonProperty]
        public JobGene Job { get; set; }

        public string Code { get; set; }

        public static bool CheckGene(string gene, string dna)
        {
            int number = 0;
            for (int i = 0; i < gene.Length; i++)
            {
                
                bool isActive = CheckString(gene, dna, number);
                if (!(isActive))
                {
                    number++;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckString(string gene, string dna, int number)
        {
            int halfOfGene = gene.Length / 2;
            string partOfGene = "";
            for (int j = 0; j < gene.Length; j++)
            {
                for (int i = j; i < halfOfGene + number; i++)
                {
                    partOfGene += i;
                }
                if (dna.Contains(partOfGene))
                {
                    return true;
                }
                else
                {
                    partOfGene = "";
                }
            }
            return false;
        }
    }
}
