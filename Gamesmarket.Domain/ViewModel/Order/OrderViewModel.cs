namespace Gamesmarket.Domain.ViewModel.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }

        public long GameId { get; set; }

        public string GameName { get; set; }

        public string GameDeveloper { get; set; }

        public List<string> GameGenres { get; set; }

        public decimal GamePrice { get; set; }

        public string ImagePath { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public DateTimeOffset DateCreated { get; set; }
    }
}