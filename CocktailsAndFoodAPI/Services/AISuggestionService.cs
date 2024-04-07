using CocktailsAndFoodAPI.Data;
using CocktailsAndFoodAPI.Plugins;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;

namespace CocktailsAndFoodAPI.Services
{
	public class AISuggestionService
	{
		public ChatHistory history { get; set; } = [];
		private readonly IChatCompletionService? chatCompletionService;
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IKernelBuilder? builder;
		private readonly Kernel? kernel;
		private readonly DataCollection _dataCollection;

		public AISuggestionService(IConfiguration configuration, IHttpClientFactory httpClientFactory,
			DataCollection dataCollection)
		{
			_httpClientFactory = httpClientFactory;
			_dataCollection = dataCollection;

			builder = Kernel.CreateBuilder();
			builder.AddOpenAIChatCompletion(configuration.GetSection("OpenAI:ModelID").Value!,
				configuration.GetSection("OpenAI:Key").Value!);
			builder.Plugins.AddFromObject(new ProductsPlugin(_httpClientFactory, _dataCollection), nameof(ProductsPlugin));
			kernel = builder.Build();
			history.AddSystemMessage(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "AISuggestionsPrompt.txt")));
			chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
		}

		public async Task<string> GetSuggestionsAsync()
		{
			history.AddUserMessage(File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "AISuggestionsPrompt.txt")));

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
	}
}
