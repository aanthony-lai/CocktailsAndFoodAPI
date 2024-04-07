using CocktailsAndFoodAPI.DTO;
using CocktailsAndFoodAPI.Entities;
using CocktailsAndFoodAPI.Interfaces;
using System.Net.Http;

namespace CocktailsAndFoodAPI.Services
{
	public class DrinksService: IDrinksService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly string[] drinkList = { "amaretto_sour", "strawberry_daiquiri", "pornstar_martini", "espresso_martini",
			"margarita", "old_fashioned" };

		public DrinksService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<DrinksDTO> GetDrinksAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var drinks = new DrinksDTO();
			foreach (var drink in drinkList)
			{
				var response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={drink}");
				var data = await response.Content.ReadFromJsonAsync<DrinksDTO>() ?? new DrinksDTO();
				drinks.drinks.AddRange(data.drinks);
			}
			return drinks;
		}
	}
}
