# TrimThisText.Console

**TrimThisText.Console** is a modern .NET 8 console application that uses AI to generate compelling titles and concise summaries from any given text. It showcases clean architecture, dependency injection, external API integration, and solid software development practices in C#.

---

## 📑 Table of Contents

- [✨ Features](#-features)
- [🛠️ Technologies Used](#️-technologies-used)
- [📁 Folder Structure](#-folder-structure)
- [🌐 Connect with Me](#-connect-with-me)

## ✨ Features

- 🤖 **AI-Powered Summarization**: Uses GPT-4 (via OpenRouter) to generate high-quality summaries.  
- 💡 **Dynamic Title Generation**: Suggests engaging titles with a 10-word limit.  
- 🔐 **.env Configuration**: API keys are managed securely via environment variables.  
- 🧩 **Dependency Injection**: Built with `IAiService` interface for flexibility and testability.  
- 🛠️ **Modular Design**: Clean folder separation for services, models, and utilities.  
- ⚠️ **Error Handling**: Handles API failures and invalid user input gracefully.

## 🛠️ Technologies Used

- **.NET 8**  
- **C# 12**  
- **HttpClient**  
- **DotNetEnv**  
- **System.Text.Json**  
- **Microsoft.Extensions.DependencyInjection**  
- **Microsoft.Extensions.Hosting**

## 📁 Folder Structure

TrimThisText.Console/  
│  
├── Configuration/              # Centralized configuration logic  
├── Models/                     # Data models (e.g., AiOptions, OutputModel)  
├── Services/                   # Service interfaces and implementations  
├── Utils/                      # Utility classes (e.g., JsonHelper)  
├── appsettings.json            # Application configuration  
├── Program.cs                  # Application entry point  
├── .env                        # Local environment variables (not committed)  
├── README.md                   # Project documentation  
└── Tests/                      # Unit and integration tests  

## 🌐 Connect with Me
- [LinkedIn](https://www.linkedin.com/in/marcelopwmendes/)
- [GitHub](https://github.com/marcelopwmendes)