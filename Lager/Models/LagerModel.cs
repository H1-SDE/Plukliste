using System.Text.Json.Serialization;

namespace Lager.Models
{
    public class LagerModel
    {
        public string ProductID { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
