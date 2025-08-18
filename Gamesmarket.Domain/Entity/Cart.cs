namespace Gamesmarket.Domain.Entity
{
    public class Cart
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>(); // Cart has many items
    }
}
