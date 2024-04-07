using CocktailsAndFoodAPI.Entities;
using CocktailsAndFoodAPI.Interfaces;

namespace CocktailsAndFoodAPI.Services
{
	public class FoodService: IFoodService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FoodService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<FoodDTO[]> GetFoodAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://iths-2024-recept-grupp9-40k2zx.reky.se/recipes");
			var data = await response.Content.ReadFromJsonAsync<FoodDTO[]>() ?? [];
			return data;
		}
	}
}
