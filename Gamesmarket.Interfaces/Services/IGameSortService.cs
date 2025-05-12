using Gamesmarket.Domain.Entity;
using Gamesmarket.Domain.Response;

namespace Gamesmarket.Interfaces.Services
{
    public interface IGameSortService
    {
        Task<IBaseResponse<IEnumerable<Game>>> SortByIdDescending();
        Task<IBaseResponse<IEnumerable<Game>>> SortByReleaseDate(bool ascending);
        Task<IBaseResponse<IEnumerable<Game>>> SortByPrice(bool ascending);
    }
}
