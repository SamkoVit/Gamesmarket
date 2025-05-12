using Gamesmarket.Domain.Entity;
using Gamesmarket.Domain.Response;
using Gamesmarket.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamesmarket.Controllers
{
    [ApiController]
    [Route("api/games/sort")]
    public class GameSortController : ControllerBase
    {
        private readonly IGameSortService _sortService;

        public GameSortController(IGameSortService sortService)
        {
            _sortService = sortService;
        }

        [HttpGet("by-id-desc")]
        public async Task<IActionResult> GetByIdDesc()
        {
            var response = await _sortService.SortByIdDescending();
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

        [HttpGet("by-release-date/{ascending}")]
        public async Task<IActionResult> GetByReleaseDate(bool ascending)
        {
            var response = await _sortService.SortByReleaseDate(ascending);
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

        [HttpGet("by-price/{ascending}")]
        public async Task<IActionResult> GetByPrice(bool ascending)
        {
            var response = await _sortService.SortByPrice(ascending);
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
