using MazeGame.Enums;
using MazeGame.Models;
using MazeGame.Models.Characters;
using MazeGame.Models.Items;

namespace MazeGame.Builders;

public class WallBuilder
{
    private Wall _wall = new();

    public WallBuilder WithType(WallType wallType)
    {
        _wall.WallType = wallType;
        return this;
    }

    public WallBuilder WithDirection(Direction direction)
    {
        _wall.Direction = direction;
        return this;
    }

    public WallBuilder WithView(View view)
    {
        _wall.View = view;
        return this;
    }

    public WallBuilder WithMonster(Monster monster)
    {
        _wall.Monster = monster;
        return this;
    }

    public WallBuilder WithTreasure(Treasure treasure)
    {
        _wall.Treasure = treasure;
        return this;
    }

    public Wall Build()
    {
        var results = _wall;
        _wall = new Wall();
        return results;
    }
}
