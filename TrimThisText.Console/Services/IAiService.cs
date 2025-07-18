namespace TrimThisText.Console.Services
{
    public interface IAiService
    {
        Task<String> AskAsync(string prompt);
    }
}
