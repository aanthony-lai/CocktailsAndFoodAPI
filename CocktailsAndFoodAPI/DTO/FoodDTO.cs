namespace CocktailsAndFoodAPI.Entities
{
	public class FoodDTO
	{
		
		public string _id { get; set; } = string.Empty;
		public string title { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public string imageUrl { get; set; } = string.Empty;
		public int timeInMins { get; set; }
		public int price { get; set; }
		public List<IngredientDTO> ingredients { get; set; } = new List<IngredientDTO>();
	}
}
