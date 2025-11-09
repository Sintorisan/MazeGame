using MazeGame.Models.Items;

namespace MazeGame.Models.Characters;

public class Hero : Character
{
  public Backpack Backpack { get; set; } = new();
  public Armor Armor { get; set; } = new();
  public Weapon Weapon { get; set; } = new();
}
