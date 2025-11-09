namespace MazeGame;

public class MapOptions
{
    public int[] MapSize { get; set; } = [];
    public int MaxMonsters { get; set; }
    public int MaxTreasures { get; set; }
    public int TotalSize => MapSize[0] * MapSize[1];
}
