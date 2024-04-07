namespace CocktailsAndFoodAPI.Entities
{
	public class Drink
	{
		public string strDrink = string.Empty;
		public string strDrinkThumb = string.Empty;
		public string idDrink = string.Empty;

		public Drink(string strDrink, string strDrinkThumb, string idDrink)
		{
			this.strDrinkThumb = strDrinkThumb;
			this.strDrink = strDrink;
			this.idDrink = idDrink;
		}
	}
}
