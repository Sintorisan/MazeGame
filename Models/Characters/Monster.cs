using MazeGame.Models.Items;

namespace MazeGame.Models.Characters;

public class Monster : Character
{
  public List<LootItem> Loot { get; set; } = new();
}
