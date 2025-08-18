namespace Gamesmarket.Domain.Entity;

public class OrderItem
{
    public long Id { get; set; }
    
    public long OrderId { get; set; }
    public Order Order { get; set; }
    
    public int GameId { get; set; }
    public Game Game { get; set; }
    
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; } // Price at the moment of purchase (can differ from current Game.Price)
}