namespace MazeGame.Models.Characters;

public class Character
{
	public string Name { get; set; } = string.Empty;
	public int Level { get; set; } = 1;
	public int Health { get; set; } = 100;
	public bool IsAlive => Health > 0;
}
