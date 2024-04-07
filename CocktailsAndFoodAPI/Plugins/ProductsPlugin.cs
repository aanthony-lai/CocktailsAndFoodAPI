using CocktailsAndFoodAPI.Data;
using CocktailsAndFoodAPI.Entities;
using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Text.Json;

namespace CocktailsAndFoodAPI.Plugins
{
	public class ProductsPlugin
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly DataCollection _dataCollection;
		private readonly string[] drinkList = { "amaretto_sour", "strawberry_daiquiri", "pornstar_martini", "espresso_martini",
			"margarita", "old_fashioned" };

		public ProductsPlugin(IHttpClientFactory httpClientFactory, DataCollection dataCollection)
		{
			_dataCollection = dataCollection;
			_httpClientFactory = httpClientFactory;
		}

		[KernelFunction, Description("Retrieving food that is available.")]
		[return: Description("Return information about a product or products in fluent text. There should " +
			"be no bullet points.")]
		public async Task<FoodDTO[]> GetFoodAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://iths-2024-recept-grupp9-40k2zx.reky.se/recipes");
			var data = await response.Content.ReadFromJsonAsync<FoodDTO[]>();
			return data ?? [];
		}

		[KernelFunction, Description("Retrieving information about all drinks that are available.")]
		[return: Description("Returns information about products")]
		public async Task<string> GetDrinksAsync()
		{
			var drinks = _dataCollection.GetDrinks();
			return JsonSerializer.Serialize(drinks.drinks) ?? "";
		}
	}
}
