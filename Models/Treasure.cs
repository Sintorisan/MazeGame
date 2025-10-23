namespace MazeGame;

public class Treasure
{
    public List<ICollectable> Content { get; set; } = new();
    public int LevelToOpen { get; set; }
}
