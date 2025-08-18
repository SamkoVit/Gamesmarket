namespace Gamesmarket.Domain.Enum
{
    public enum FriendshipStatus
    {
        Pending = 0,    // User A sent a request to User B

        Accepted = 1,   // User B accepted User A's request

        Declined = 2,   // User B declined User A's request

        Blocked = 3,    // One user blocked the other

        Removed = 4,    // One user unfriended the other
    }
}
