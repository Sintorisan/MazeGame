using MazeGame.Interfaces;
using MazeGame.Models.Items;

namespace MazeGame.Models.Characters;

public class Backpack
{
    public int Size { get; set; }
    public List<LootItem> Inventory { get; set; } = new();
    public CoinPouch CoinPouch { get; set; } = new();

}
