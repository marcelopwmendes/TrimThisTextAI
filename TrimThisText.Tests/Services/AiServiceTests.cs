using FluentAssertions;
using Moq;
using TrimThisText.Console.Services;

namespace TrimThisText.Tests.Services
{
    public class AiServiceTests
    {
        [Fact]
        public async Task AskAsync_ReturnsExpectedString()
        {
            // Arrange
            string prompt = "Hello, AI!";
            string expectedResponse = "Hi there!";
            Mock<IAiService> mockService = new();
            mockService.Setup(s => s.AskAsync(prompt)).ReturnsAsync(expectedResponse);

            // Act
            string result = await mockService.Object.AskAsync(prompt);

            // Assert
            result.Should().Be(expectedResponse);
        }

        [Fact]
        public async Task AskAsync_WithEmptyPrompt_ReturnsEmptyString()
        {
            // Arrange
            string prompt = string.Empty;
            string expectedResponse = string.Empty;
            Mock<IAiService> mockService = new();
            mockService.Setup(s => s.AskAsync(prompt)).ReturnsAsync(expectedResponse);

            // Act
            string result = await mockService.Object.AskAsync(prompt);

            // Assert
            result.Should().Be(expectedResponse);
        }

        [Fact]
        public async Task AskAsync_WithNullPrompt_ThrowsArgumentNullException()
        {
            // Arrange
            string? prompt = null;
            Mock<IAiService> mockService = new();
            mockService
                .Setup(s => s.AskAsync(prompt!))
                .ThrowsAsync(new ArgumentNullException(nameof(prompt)));

            // Act
            Func<Task> act = async () => await mockService.Object.AskAsync(prompt!);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task AskAsync_WhenServiceThrowsException_PropagatesException()
        {
            // Arrange
            string prompt = "error";
            Mock<IAiService> mockService = new();
            mockService
                .Setup(s => s.AskAsync(prompt))
                .ThrowsAsync(new InvalidOperationException("Service error"));

            // Act
            Func<Task> act = async () => await mockService.Object.AskAsync(prompt);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage("Service error");
        }

    }
}
