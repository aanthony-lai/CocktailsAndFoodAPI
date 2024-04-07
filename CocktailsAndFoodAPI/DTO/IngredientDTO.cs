using System.ComponentModel.DataAnnotations;

namespace CocktailsAndFoodAPI.Entities
{
	public class IngredientDTO
	{
		[Key]
		public string _id { get; set; } = string.Empty;
		public string name { get; set; } = string.Empty;
		public int amount { get; set; } 
		public string unit { get; set; } = string.Empty;
	}
}
