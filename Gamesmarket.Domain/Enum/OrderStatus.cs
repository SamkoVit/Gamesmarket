namespace Gamesmarket.Domain.Enum
{
    public enum OrderStatus
    {
        Pending = 0,      // Order created but not yet paid/processed

        Processing = 1,   // Payment received, fulfillment in progress

        Completed = 2,    // Game delivered

        Cancelled = 3,    // Order cancelled before completion

        Refunded = 4      // Order was completed but later refunded
    }
}
