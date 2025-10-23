

using System.Text.Json;

namespace MazeGame;

public class FieldGenerator
{
	private List<Room> Rooms { get; set; }

	public FieldGenerator()
	{
		var projectPath = AppDomain.CurrentDomain.BaseDirectory;
		var dataPath = Path.Combine(projectPath, "Data", "rooms.json");
		var data = File.ReadAllText(dataPath);

		Rooms = JsonSerializer.Deserialize<List<Room>>(data)!;
	}


	public Room[,] CreateField()
	{
		Room[,] playingField = new Room[5, 5];
		for (int i = 0; i < playingField.GetLength(0); i++)
		{
			for (int j = 0; j < playingField.GetLength(1); j++)
			{
				playingField[i, j] = AddRandomRoom();
			}
		}

		return playingField;
	}

	private Room AddRandomRoom()
	{
		var rnd = new Random();
		int rndRoomIndex = rnd.Next(0, Rooms.Count);
		var roomToAdd = Rooms[rndRoomIndex];
		Rooms.RemoveAt(rndRoomIndex);
		return roomToAdd;
	}
}
