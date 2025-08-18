using Gamesmarket.Domain.Enum;

namespace Gamesmarket.Domain.Entity;

public class Payment
{
    public long Id { get; set; }
    
    public long OrderId { get; set; }
    public Order Order { get; set; }
    
    public DateTime PaymentDate { get; set; }
    
    public decimal Amount { get; set; }
    
    public PaymentStatus Status { get; set; }
    
}