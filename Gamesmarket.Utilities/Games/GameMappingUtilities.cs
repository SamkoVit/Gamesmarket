using Gamesmarket.Domain.Entity;
using Gamesmarket.Domain.Enum;
using Gamesmarket.Domain.ViewModel.Game;

namespace Gamesmarket.Utilities.Games
{
    public static class GameMappingUtilities
    {
        public static Game CreateGameFromViewModel(GameViewModel gameViewModel, string imagePath)
        {
            var selectedGenres = gameViewModel.SelectedGenres
                .Select(g => new GameGenreTag { Genre = (GameGenre)Convert.ToInt32(g) })
                .ToList();
            
            return new Game
            {
                Description = gameViewModel.Description,
                ReleaseDate = gameViewModel.ReleaseDate,
                Developer = gameViewModel.Developer,
                Price = gameViewModel.Price,
                Name = gameViewModel.Name,
                GameGenres = selectedGenres,
                ImagePath = imagePath,
            };
        }

        public static GameViewModel CreateViewModelFromGame(Game game)
        {
            return new GameViewModel
            {
                Id = game.Id,
                Description = game.Description,
                ReleaseDate = game.ReleaseDate,
                Developer = game.Developer,
                Price = game.Price,
                Name = game.Name,
                SelectedGenres = game.GameGenres.Select(g => ((int)g.Genre).ToString()).ToList(),
            };
        }

        public static void UpdateGameFromViewModel(Game game, GameViewModel model)
        {
            game.Description = model.Description;
            game.Developer = model.Developer;
            game.ReleaseDate = model.ReleaseDate;
            game.Price = model.Price;
            game.Name = model.Name;
            game.GameGenres
                .Select(g => new GameGenreTag { Genre = (GameGenre)Convert.ToInt32(g) })
                .ToList();
        } 
    }
}
