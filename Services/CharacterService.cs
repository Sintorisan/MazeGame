
using MazeGame.Models.Characters;

namespace MazeGame.Services;

public class CharacterService
{
  public Hero CreatePlayer()
  {
    Console.WriteLine("Hi and welcome to Super Awesome Dungeon Game!");
    Console.Write("What is your name young warrior?: ");
    var userName = Console.ReadLine();

    return new Hero { Name = userName! };
  }
}
