using Gamesmarket.Domain.Enum;

namespace Gamesmarket.Domain.Entity
{
    public class Order
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
        
        public DateTime DateCreated { get; set; }
        public decimal TotalAmount { get; set; } // Calculated sum of OrderItems at time of creation

        public OrderStatus Status { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>(); // the actual items bought in this order
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
