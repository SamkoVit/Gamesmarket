using Gamesmarket.Domain.Enum;

namespace Gamesmarket.Domain.Entity
{
    public class Friendship
    {
        public int Id { get; set; }

        public long User1Id { get; set; }
        public User User1 { get; set; }

        public long User2Id { get; set; }
        public User User2 { get; set; }
        
        public FriendshipStatus FriendshipStatus { get; set; }

        public long ActionUserId { get; set; } // If the FriendshipStatus changes store the ID of the user who initiated that change
        public User ActionUser { get; set; }
        
        public DateTime RequestedDate { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
