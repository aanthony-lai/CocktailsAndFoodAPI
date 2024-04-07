using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;
using CocktailsAndFoodAPI.Plugins;
using CocktailsAndFoodAPI.Data;

namespace CocktailsAndFoodAPI.Services
{
	public class ChatService
	{
		public ChatHistory history { get; set; } = [];
		private readonly IChatCompletionService? chatCompletionService;
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IKernelBuilder? builder;
		private readonly Kernel? kernel;
		private readonly DataCollection _dataCollection;

		public ChatService(IConfiguration configuration, IHttpClientFactory httpClientFactory,
			DataCollection dataCollection)
		{
			_httpClientFactory = httpClientFactory;
			_dataCollection = dataCollection;

			builder = Kernel.CreateBuilder();
			builder.AddOpenAIChatCompletion(configuration.GetSection("OpenAI:ModelID").Value!,
				configuration.GetSection("OpenAI:Key").Value!);
			builder.Plugins.AddFromObject(new ProductsPlugin(_httpClientFactory, _dataCollection), nameof(ProductsPlugin));
			kernel = builder.Build();
			history.AddSystemMessage(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SystemPrompt.txt")));
			chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
		}

		public async Task<string> SendMessage(string userMessage)
		{
			history.AddUserMessage(userMessage);

			OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
			{
				ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
			};

			string combinedResponse = string.Empty;

			var response = await chatCompletionService.GetChatMessageContentsAsync(
				history,
				openAIPromptExecutionSettings,
				kernel: kernel);

			foreach (var message in response)
			{
				return combinedResponse += message;
			}

			history.AddAssistantMessage(combinedResponse);
			return combinedResponse;
		}

		public void ClearChat()
		{
			history.Clear();
		}
	}
}
