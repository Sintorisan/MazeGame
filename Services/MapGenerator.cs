using MazeGame.Enums;
using MazeGame.Factories;
using MazeGame.Models;

namespace MazeGame.Services;

public class MapGenerator
{
	public static Map GenerateMap(MapOptions opt)
	{
		var rooms = CreateRooms(opt);

		var map = new Map
		{
			Options = opt,
			Rooms = GenerateMapLayout(rooms, opt)
		};

		return map;
	}

	private static Room[,] GenerateMapLayout(List<Room> rooms, MapOptions opt)
	{
		throw new NotImplementedException();
	}

	private static List<Room> CreateRooms(MapOptions opt)
	{
		var rooms = new List<Room>();
		var rnd = new Random();

		for (int i = 0; i < opt.TotalSize; i++)
		{
			var factory = new RoomFactory();

			bool tooManyMonsters = rooms.Count(r => r.RoomType == RoomType.MonsterRoom) >= opt.MaxMonsters;
			bool tooManyTreasures = rooms.Count(r => r.RoomType == RoomType.TreasureRoom) >= opt.MaxTreasures;

			RoomType selectedType;

			while (true)
			{
				var roll = rnd.Next(3);

				selectedType = roll switch
				{
					0 => RoomType.MonsterRoom,
					1 => RoomType.TreasureRoom,
					_ => RoomType.RegularRoom
				};

				if (selectedType == RoomType.MonsterRoom && tooManyMonsters) continue;
				if (selectedType == RoomType.TreasureRoom && tooManyTreasures) continue;
				break;
			}

			var room = selectedType switch
			{
				RoomType.MonsterRoom => factory.MonsterRoom(),
				RoomType.TreasureRoom => factory.TreasureRoom(),
				_ => factory.RegularRoom()
			};

			rooms.Add(room);
		}

		return rooms;
	}

}