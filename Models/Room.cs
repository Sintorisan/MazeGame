namespace MazeGame;

public class Room
{
	public string Message { get; set; } = string.Empty;
	public bool IsDone { get; set; }
	public bool ContainsDiamond { get; set; }
	public bool ContainsMonster { get; set; }
	public Monster? Monster { get; set; }
}
