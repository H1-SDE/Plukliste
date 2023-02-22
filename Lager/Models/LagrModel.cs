using System.Text.Json.Serialization;

namespace Lager.Models
{
    public class LageModel
    {
        [JsonPropertyName("produckId")]
        public string ProduckID { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("amount")]
        public string Amount { get; set; }
    }
}
