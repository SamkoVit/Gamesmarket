using Microsoft.AspNetCore.Http;

namespace Gamesmarket.Domain.ViewModel.Game
{
    public class GameViewModel
    {//Model to simplify data transfer between service and controller
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Developer { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        public List<string> SelectedGenres { get; set; } = new();

        public IFormFile ImageFile { get; set; }

    }
}
