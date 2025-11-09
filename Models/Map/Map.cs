namespace MazeGame.Models;

public class Map
{
    public MapOptions Options { get; set; } = new();
    public Room[,]? Rooms { get; set; }
}
