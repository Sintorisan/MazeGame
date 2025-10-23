namespace MazeGame;

public class Room
{
	public string Message { get; set; } = string.Empty;
	public bool IsDone { get; set; }
	public bool ContainsTreasure { get; set; }
	public bool ContainsMonster { get; set; }
	public List<Wall> Walls { get; set; } = new();
	public Treasure? Treasure { get; set; }
	public Monster? Monster { get; set; }
}
