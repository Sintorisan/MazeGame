using MazeGame.Models.Characters;

namespace MazeGame.Interfaces;

public interface IConsumable
{
    void Consume(Hero hero);
}
