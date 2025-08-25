using Gamesmarket.Domain.Enum;

namespace Gamesmarket.Domain.ViewModel.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }

        public string BuyerEmail { get; set; }

        public string BuyerName { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public decimal TotalPrice { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderItemViewModel> Items { get; set; } = new();
    }
}