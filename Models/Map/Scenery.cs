using MazeGame.Enums;

namespace MazeGame.Models;

public class Scenery
{
    public string RoomScenery { get; set; } = string.Empty;
    public RoomType RoomType { get; set; }
}
