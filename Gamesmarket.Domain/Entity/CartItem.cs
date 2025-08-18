namespace Gamesmarket.Domain.Entity;

public class CartItem
{
    public long Id { get; set; }
    
    public long CartId { get; set; }
    public Cart Cart { get; set; }
    
    public int GameId { get; set; }
    public Game Game { get; set; }
    
    public int Quantity { get; set; }
    public decimal PriceAtAddition { get; set; }
}