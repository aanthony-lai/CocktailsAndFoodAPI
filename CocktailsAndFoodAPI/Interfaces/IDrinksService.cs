using CocktailsAndFoodAPI.DTO;

namespace CocktailsAndFoodAPI.Interfaces
{
	public interface IDrinksService
	{
		Task<DrinksDTO> GetDrinksAsync();
	}
}
