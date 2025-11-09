namespace MazeGame.Models.Items;

public class Treasure
{
    public List<LootItem> Content { get; set; } = new();
    public int LevelToOpen { get; set; }
}
