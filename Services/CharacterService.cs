
namespace MazeGame;

public class CharacterService
{
  public Hero CreatePlayer()
  {
    Console.WriteLine("Hi and welcome to the super awesome maze!");
    Console.Write("What is your name young warrior?: ");
    var userName = Console.ReadLine();

    return new Hero { Name = userName! };
  }
}
