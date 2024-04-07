using CocktailsAndFoodAPI.DTO;
using CocktailsAndFoodAPI.Entities;
using CocktailsAndFoodAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CocktailsAndFoodAPI.Controllers
{
	[Route("api/drinks")]
	[ApiController]
	public class DrinksController : ControllerBase
	{
		private readonly IDrinksService _drinksService;

		public DrinksController(IDrinksService drinksService)
		{
			_drinksService = drinksService;
		}

		[HttpGet]
		public async Task<ActionResult<List<FoodDTO>>> GetDrinks()
		{
			var data = await _drinksService.GetDrinksAsync();
			return Ok(data); 
		}

		
	}
}
