using CocktailsAndFoodAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CocktailsAndFoodAPI.Controllers
{
	[Route("api/chat")]
	[ApiController]
	public class ChatController : ControllerBase
	{
		//private readonly ChatService _chatService;
		//private readonly AISuggestionService _suggestionService;

		//public ChatController(ChatService chatService, AISuggestionService suggestionService)
		//{
		//	_chatService = chatService;
		//	_suggestionService = suggestionService;
		//}

		//[HttpPost]
		//public async Task<ActionResult<string>> SendMessageAsync([FromBody] string userMessage)
		//{
		//	var response = await _chatService.SendMessage(userMessage);
		//	return Ok(response);
		//}

		//[HttpPost("suggestions")]
		//public async Task<ActionResult<string>> GetSuggestionsAsync()
		//{
		//	var response = await _suggestionService.GetSuggestionsAsync();
		//	return Ok(response);
		//}

		//[HttpPost("clear")]
		//public ActionResult ClearChat()
		//{
		//	_chatService.ClearChat();
		//	return NoContent();
		//}
	}
}
