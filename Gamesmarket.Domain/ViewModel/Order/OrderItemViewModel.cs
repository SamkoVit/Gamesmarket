namespace Gamesmarket.Domain.ViewModel.Order
{
    public class OrderItemViewModel
    {
        public long GameId { get; set; }

        public string GameName { get; set; }

        public string Developer { get; set; }

        public List<string> Genres { get; set; }

        public decimal PriceAtPurchase { get; set; }

        public int Quantity { get; set; }

        public string ImagePath { get; set; }
    }
}