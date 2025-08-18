namespace Gamesmarket.Domain.Entity
{
    public class OwnedGame
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
        
        public int GameId { get; set; }
        public Game Game { get; set; }
        
        public DateTime AcquiredAt { get; set; }

        public long? GiftFromUserId { get; set; }
        public User? GiftFromUser { get; set; }
        
        public bool IsGift => GiftFromUserId.HasValue;

    }
}
