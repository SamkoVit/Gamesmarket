namespace Gamesmarket.Domain.Entity
{
    public class Game
    {//A data model about the games
        public int Id { get; set; }

        public string Name { get; set; }

        public string Developer { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        public string ImagePath { get; set; }

        public ICollection<GameGenreTag> GameGenres { get; set; } = new List<GameGenreTag>();
        public ICollection<OwnedGame> OwnedGames { get; set; } = new List<OwnedGame>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }

}
