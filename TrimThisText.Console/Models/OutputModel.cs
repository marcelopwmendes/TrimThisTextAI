using System.Text.Json.Serialization;

namespace TrimThisText.Console.Models
{
    public class OutputModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }
    }
}
