using MazeGame.Enums;
using MazeGame.Models.Characters;
using MazeGame.Models.Items;

namespace MazeGame.Models;

public class Wall
{
    public View View { get; set; } = new();
    public WallType WallType { get; set; }
    public Treasure? Treasure { get; set; }
    public Monster? Monster { get; set; }
    public Direction Direction { get; set; }
    public bool IsPassable { get; set; }
}
