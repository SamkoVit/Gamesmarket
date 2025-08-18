using Gamesmarket.Domain.Enum;

namespace Gamesmarket.Domain.Entity;

public class GameGenreTag
{
    public int GameId { get; set; }
    
    public Game Game { get; set; }
    
    public GameGenre Genre { get; set; }
}