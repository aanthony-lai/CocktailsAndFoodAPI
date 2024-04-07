using CocktailsAndFoodAPI.Entities;

namespace CocktailsAndFoodAPI.Interfaces
{
	public interface IFoodService
	{
		Task<FoodDTO[]> GetFoodAsync();
	}
}
