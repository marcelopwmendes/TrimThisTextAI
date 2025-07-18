using System.Net.Http.Json;
using System.Text.Json;
using TrimThisText.Console.Models;

namespace TrimThisText.Console.Services
{
    public class AiService : IAiService
    {
        private readonly HttpClient _httpClient;
        public readonly string _requestUri = "chat/completions";
        private readonly string _model = "openai/gpt-4o";
        private readonly string _basePrompt = "Based on the following text: 1. Suggest a compelling title (maximum 10 words). 2. Summarize the text in no more than 500 characters. Text: ";
        private readonly string _suffixPrompt = "Return the result as a JSON object with keys 'title' and 'summary'. Do not include markdown formatting.";

        public AiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> AskAsync(string prompt)
        {
            var requestBody = new
            {
                model = _model,
                messages = new[]
                {
                    new { role = "system", content = "The assistant is a professional summarizer. He should be able to reply in the language that user is using" },
                    new { role = "user", content = _basePrompt + prompt + _suffixPrompt}
                },
                max_tokens = 1000
            };

            StringContent content = new(JsonSerializer.Serialize(requestBody));

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(_requestUri, content);
                response.EnsureSuccessStatusCode();
                String s = await response.Content.ReadAsStringAsync();
                AiResponse aiResponse = await response.Content.ReadFromJsonAsync<AiResponse>();
                return aiResponse?.Choices?.FirstOrDefault()?.Message?.Content;
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("HttpRequestException", ex);
            }
        }
    }
}
