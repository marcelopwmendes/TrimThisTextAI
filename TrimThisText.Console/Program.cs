using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using TrimThisText.Console.Configuration;
using TrimThisText.Console.Models;
using TrimThisText.Console.Services;
using TrimThisText.Console.Utils;

DotNetEnv.Env.Load();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        IConfiguration configuration = context.Configuration;
        AiOptions aiOptions = AppConfiguration.GetOptions<AiOptions>(configuration, "AiOptions");

        // Substitui ApiKey pelo valor da variável de ambiente, se existir
        var envApiKey = Environment.GetEnvironmentVariable("OPENROUTER_API_KEY");
        if (!string.IsNullOrWhiteSpace(envApiKey))
        {
            aiOptions.ApiKey = envApiKey;
        }

        // Registra as opções já atualizadas
        services.Configure<AiOptions>(opts =>
        {
            opts.ApiKey = aiOptions.ApiKey;
            opts.BaseUrl = aiOptions.BaseUrl;
        });

        services.AddHttpClient<IAiService, AiService>((provider, client) =>
        {
            AiOptions options = provider.GetRequiredService<IOptions<AiOptions>>().Value;

            client.BaseAddress = new Uri(options.BaseUrl);
            client.DefaultRequestHeaders.Authorization = new("Bearer", options.ApiKey);
            client.DefaultRequestHeaders.Accept.Add(new("application/json"));
        });
    })
    .Build();

IAiService aiService = host.Services.GetRequiredService<IAiService>();

Console.WriteLine("Text to trim: ");
String input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Input cannot be empty. Please provide valid text.");
    return;
}

String result = await aiService.AskAsync(input);
OutputModel outputModel = JsonHelper.Deserialize<OutputModel>(result) ?? new OutputModel
{
    Title = "No title",
    Summary = "No summary"
};

Console.WriteLine("Title: " + outputModel.Title);
Console.WriteLine("Summary: " + outputModel.Summary);

Console.ReadLine();