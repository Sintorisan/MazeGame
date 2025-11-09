using MazeGame.Models.Items;

namespace MazeGame.Models.Characters;

public class CoinPouch
{
    public List<GoldCoin> Coins { get; set; } = new();

    public int GetPouchValue()
    {
        return Coins.Sum(c => c.Amount);
    }
}
