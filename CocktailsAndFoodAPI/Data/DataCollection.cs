using CocktailsAndFoodAPI.Entities;

namespace CocktailsAndFoodAPI.Data
{
	public class DataCollection
	{
		private readonly Drinks _drinks;

		public DataCollection(Drinks drinks)
		{
			_drinks = drinks;
		}

		public Drinks GetDrinks()
		{
			return _drinks;
		}
	}
}
