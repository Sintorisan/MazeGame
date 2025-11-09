using System.Text.Json.Serialization;

namespace MazeGame.Models.Items;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(HealthItem), "HealthItem")]
[JsonDerivedType(typeof(Diamond), "Diamond")]
[JsonDerivedType(typeof(GoldCoin), "GoldCoin")]
[JsonDerivedType(typeof(Weapon), "Weapon")]
[JsonDerivedType(typeof(Armor), "Armor")]
public abstract class LootItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Size { get; set; } = 1;

    public virtual string GetDescription() =>
        $"Name: {Name} - Size: ({Size})";
}
