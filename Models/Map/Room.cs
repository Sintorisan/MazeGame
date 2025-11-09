
using MazeGame.Enums;

namespace MazeGame.Models;

public class Room
{
	public Scenery? Scenery { get; set; }
	public RoomType RoomType { get; set; }
	public bool IsDone { get; set; }
	public List<Wall> Walls { get; set; } = new();

}
