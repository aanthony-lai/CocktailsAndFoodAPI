using CocktailsAndFoodAPI.Entities;
using CocktailsAndFoodAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CocktailsAndFoodAPI.Controllers
{
	[Route("api/food")]
	[ApiController]
	public class FoodController : ControllerBase
	{
		private readonly IFoodService _foodService;

		public FoodController(IFoodService foodService)
		{
			_foodService = foodService;
		}

		[HttpGet]
		public async Task<ActionResult<FoodDTO[]>> GetFood()
		{
			var data = await _foodService.GetFoodAsync();
			return Ok(data);
		}
	}
}
