using Gamesmarket.Domain.Entity;
using Gamesmarket.Domain.Enum;
using Gamesmarket.Domain.Response;
using Gamesmarket.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamesmarket.Controllers
{
    [ApiController]
    [Route("api/games/search")]
    public class GameSearchController : ControllerBase
    {
        private readonly IGameSearchService _gameSearchService;

        public GameSearchController(IGameSearchService gameSearchService)
        {
            _gameSearchService = gameSearchService;
        }

        [HttpGet("by-name-or-developer/{searchQuery}")]
        public async Task<IActionResult> FindGamesByNameOrDev(string searchQuery)
        {
            var response = await _gameSearchService.SearchGames(searchQuery);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return Ok(response.Data);
            }
            else
            {
                var concreteResponse = (BaseResponse<IEnumerable<Game>>)response;
                return BadRequest(concreteResponse.Description);
            }
        }

        [HttpGet("by-genre/{genre}")]
        public async Task<IActionResult> GetGamesByGenre(GameGenre genre)
        {
            var response = await _gameSearchService.GetGamesByGenre(genre);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return Ok(response.Data);
            }
            else
            {
                var concreteResponse = (BaseResponse<IEnumerable<Game>>)response;
                return BadRequest(concreteResponse.Description);
            }
        }

    }
}
