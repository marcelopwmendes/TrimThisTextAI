using System.Text.Json.Serialization;

namespace TrimThisText.Console.Models
{
    public class AiResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("choices")]
        public Choice[] Choices { get; set; }

        [JsonPropertyName("usage")]
        public ResponseUsage Usage { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        public class Choice
        {
            [JsonPropertyName("finish_reason")]
            public string FinishReason { get; set; }

            [JsonPropertyName("native_finish_reason")]
            public string NativeFinishReason { get; set; }

            [JsonPropertyName("message")]
            public ChoiceMessage Message { get; set; }

            public class ChoiceMessage
            {
                [JsonPropertyName("role")]
                public string Role { get; set; }

                [JsonPropertyName("content")]
                public string Content { get; set; }
            }
        }

        public class ResponseUsage
        {
            [JsonPropertyName("prompt_tokens")]
            public int PromptTokens { get; set; }

            [JsonPropertyName("completion_tokens")]
            public int CompletionTokens { get; set; }

            [JsonPropertyName("total_tokens")]
            public int TotalTokens { get; set; }
        }

    }
}
