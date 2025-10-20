using MazeGame;

FieldGenerator _fieldGen = new FieldGenerator();
var playingField = _fieldGen.CreateField();

CharacterService _charService = new CharacterService();
var player = _charService.CreatePlayer();

int yAxis = 4;
int xAxis = 2;

PresentRoom();


while (true)
{
	var direction = Console.ReadKey();
	switch (direction.Key)
	{
		case ConsoleKey.UpArrow:
			if (WallCheck(yAxis))
			{
				Console.WriteLine("You silly human! You cant walk through walls!");
				break;
			}
			yAxis--;
			break;

		case ConsoleKey.DownArrow:
			if (WallCheck(yAxis))
			{
				Console.WriteLine("You silly human! You cant walk through walls!");
				break;
			}
			yAxis++;
			break;

		case ConsoleKey.LeftArrow:
			if (WallCheck(xAxis))
			{
				Console.WriteLine("You silly human! You cant walk through walls!");
				break;
			}
			xAxis--;
			break;

		case ConsoleKey.RightArrow:
			if (WallCheck(xAxis))
			{
				Console.WriteLine("You silly human! You cant walk through walls!");
				break;
			}
			xAxis++;
			break;

		default:
			Console.WriteLine("Oh no! It seems like the air is making you a bit confused. Please use the arrow keys.");
			break;
	}

	PresentRoom();
}

void PresentRoom()
{
	var room = playingField[yAxis, xAxis];

	Console.WriteLine(room.Message);

	if (room.ContainsMonster)
	{
		CombatMode();
	}
	if (room.ContainsDiamond)
	{
		CollectDiamond();
	}
	if (room.IsDone)
	{
		Console.WriteLine("This all seems so familiar!");
	}

	room.IsDone = true;
}

void CollectDiamond()
{
	player.Inventory++;
	Console.WriteLine("");
}

void CombatMode()
{
	throw new NotImplementedException();
}

bool WallCheck(int axis) => axis == -4 || axis == 4;