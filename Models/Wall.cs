namespace MazeGame;

public class Wall
{
    public string View { get; set; } = string.Empty;
    public bool IsPassable { get; set; }
    public Room? NextRoom { get; set; }
}
