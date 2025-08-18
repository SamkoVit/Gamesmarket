using Microsoft.AspNetCore.Identity;

namespace Gamesmarket.Domain.Entity
{
    public class User : IdentityUser<long>
    {//An Identity data model for user authorization with jwt token
        public string Name { get; set; } = null!;

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public Cart Cart { get; set; }

        // One-to-Many relationships
        // List<>() to avoid NullReferenceExceptions if accessed before EF loads data.
        public ICollection<OwnedGame> OwnedGames { get; set; } = new List<OwnedGame>();
        public ICollection<Friendship> FriendshipAsUser1 { get; set; } = new List<Friendship>();
        public ICollection<Friendship> FriendshipAsUser2 { get; set; } = new List<Friendship>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
