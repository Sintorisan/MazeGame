using MazeGame.Enums;
using MazeGame.Interfaces;
using MazeGame.Models.Characters;

namespace MazeGame.Models.Items;

public class HealthItem : LootItem, IConsumable
{
    public string HealthType { get; set; } = string.Empty;
    public int HealPower { get; set; }

    public void Consume(Hero hero)
    {
        hero.Health = Math.Min(hero.Health + HealPower, 100);
    }

    public override string GetDescription()
    {
        return $"Name: {HealthType}(+{HealPower}) - Size: ({Size})";
    }
}
