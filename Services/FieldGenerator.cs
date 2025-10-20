

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

		playingField[4, 2] = SetStaringRoom();

		return playingField;
	}

	private Room SetStaringRoom()
	{
		return new Room
		{
			IsDone = true,
			Message = "Welcome, adventurer! \n\nYou awaken in a dimly lit stone chamber deep underground. The air is cold and echoes with distant growls.\n\nYour goal is simple:\n- Use the arrow keys to move through the maze.\n- Collect all the hidden diamonds.\n- Beware of monsters lurking in the dark — some rooms are not safe.\n\nGood luck, brave explorer!"
		};
	}

	private Room AddRandomRoom()
	{
		var rnd = new Random();
		int rndRoomIndex = rnd.Next(0, Rooms.Count - 1);
		var roomToAdd = Rooms[rndRoomIndex];
		Rooms.RemoveAt(rndRoomIndex);
		return roomToAdd;
	}
}
