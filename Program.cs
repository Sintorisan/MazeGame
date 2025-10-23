using System.Text;
using System.Threading.Tasks;
using MazeGame;

Console.Clear();

FieldGenerator _fieldGen = new FieldGenerator();
var playingField = _fieldGen.CreateField();

CharacterService _charService = new CharacterService();
var player = _charService.CreatePlayer();
var random = new Random();


int yAxis = 2;
int xAxis = 2;

Room currentRoom = playingField[yAxis, xAxis];
Console.WriteLine($"Welcome, adventurer {player.Name}! \n\nYou awaken in a dimly lit stone chamber deep underground. The air is cold and echoes with distant growls.\n\nYour goal is simple:\n- Use the arrow keys to move through the maze.\n- Collect all the hidden diamonds.\n- Beware of monsters lurking in the dark — some rooms are not safe.\n\nGood luck, brave explorer!");
Console.WriteLine("\nPress any key to begin your journey...");
Console.ReadKey();
Console.Clear();

while (true)
{
    ShowStatusBar();

    Console.WriteLine("Choose a direction you want to go!");
    var direction = Console.ReadKey();
    Console.Clear();

    switch (direction.Key)
    {
        case ConsoleKey.UpArrow:
            yAxis--;
            if (WallCheck(yAxis))
            {
                yAxis++;
                Console.WriteLine("You silly human! You cant walk through walls!");
                Console.ReadKey();
                Console.Clear();
                break;
            }
            SetCurrentRoom();
            await PresentRoom();
            break;

        case ConsoleKey.DownArrow:
            yAxis++;
            if (WallCheck(yAxis))
            {
                yAxis--;
                Console.WriteLine("You silly human! You cant walk through walls!");
                Console.ReadKey();
                Console.Clear();
                break;
            }
            SetCurrentRoom();
            await PresentRoom();
            break;

        case ConsoleKey.LeftArrow:
            xAxis--;
            if (WallCheck(xAxis))
            {
                xAxis++;
                Console.WriteLine("You silly human! You cant walk through walls!");
                Console.ReadKey();
                Console.Clear();
                break;
            }
            SetCurrentRoom();
            await PresentRoom();
            break;

        case ConsoleKey.RightArrow:
            xAxis++;
            if (WallCheck(xAxis))
            {
                xAxis--;
                Console.WriteLine("You silly human! You cant walk through walls!");
                Console.ReadKey();
                Console.Clear();
                break;
            }
            SetCurrentRoom();
            await PresentRoom();
            break;

        default:
            Console.WriteLine("Oh no! It seems like the air is making you a bit confused. Please use the arrow keys.");
            Console.Clear();
            break;
    }
}

void ShowStatusBar()
{
    Console.BackgroundColor = ConsoleColor.DarkGray;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine($"Level: {player.Level} --- Health: {player.Health} --- Diamonds: {player.Inventory}");
    Console.ResetColor();
    Console.WriteLine();

    for (int y = 0; y < 5; y++)
    {
        for (int x = 0; x < 5; x++)
        {
            if (y == yAxis && x == xAxis)
                Console.Write("[X] ");
            else if (playingField[y, x].IsDone)
                Console.Write("[ ] ");
            else
                Console.Write("[?] ");
        }
        Console.WriteLine();
    }
}

void SetCurrentRoom()
{
    currentRoom = playingField[yAxis, xAxis];
}

async Task PresentRoom()
{

    Console.Clear();
    ShowStatusBar();
    if (currentRoom.ContainsMonster)
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(currentRoom.Message);

        await CombatMode();
        playingField[yAxis, xAxis].ContainsMonster = false;

        Console.Clear();
    }
    if (currentRoom.ContainsTreasure)
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine(currentRoom.Message);
        CollectDiamond();
        Console.ReadKey();
        Console.Clear();
        playingField[yAxis, xAxis].ContainsTreasure = false;
    }
    if (currentRoom.IsDone)
    {
        Console.WriteLine(currentRoom.Message);
        Console.WriteLine("This all seems so familiar!");
        Console.ReadKey();
        Console.Clear();
    }

    playingField[yAxis, xAxis].IsDone = true;
    Console.Clear();
}

void CollectDiamond()
{
    player.Inventory++;
    Console.WriteLine("Wow you found a diamond!\n");
    Console.WriteLine($"Now you have {player.Inventory} diamonds!");
    Console.ResetColor();
}

async Task CombatMode()
{
    Console.WriteLine($"You're met by {currentRoom.Monster!.Name} (Level {currentRoom.Monster.Level})");
    Console.WriteLine("Press any key to start the battle!");
    Console.ResetColor();
    Console.ReadKey();
    Console.Clear();
    while (true)
    {
        Console.WriteLine("----<>-><-<>-><-<>-><-<>-><-<>-><-<>----");
        Console.WriteLine($"Your health: {player.Health} --- {currentRoom.Monster.Name}(Level {currentRoom.Monster.Level}) health: {currentRoom.Monster.Health}");
        Console.WriteLine("----<>-><-<>-><-<>-><-<>-><-<>-><-<>----");
        Console.WriteLine();

        Attack(player, currentRoom.Monster);
        if (!currentRoom.Monster.IsAlive)
        {
            player.Level++;
            player.Health += 100;

            Console.WriteLine($"You defeated {currentRoom.Monster.Name}!");
            Console.WriteLine($"You're now in level {player.Level}");
            Console.ReadKey();
            break;
        }
        await Task.Delay(750);

        Console.WriteLine();

        Attack(currentRoom.Monster, player);
        if (!player.IsAlive)
        {
            Console.WriteLine("You died! Game over!");
            Environment.Exit(0);
        }
        await Task.Delay(1000);
        Console.Clear();
    }
    ;
}

bool WallCheck(int axis) => axis < 0 || axis > 4;

void Attack(Character attacker, Character defender)
{
    int baseChance = 70;
    int levelChance = baseChance + (attacker.Level - defender.Level) * 10;

    levelChance = Math.Clamp(levelChance, 10, 90);

    int roll = random.Next(1, 101);

    Console.WriteLine($"{attacker.Name} takes a swing!");

    if (roll <= levelChance)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        var damage = CalculateDamage(attacker, defender);
        defender.Health -= damage;
        Console.WriteLine($"<>- HIT {damage} HIT -<>");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("<>- MISS -<>");
        Console.ResetColor();
    }
}

int CalculateDamage(Character attacker, Character defender)
{
    int baseDamage = random.Next(10, 16);
    int levelBonus = (attacker.Level - defender.Level) * 2;

    int damage = baseDamage + levelBonus;

    return Math.Max(damage, 1);
}