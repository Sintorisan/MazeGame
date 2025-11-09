using MazeGame.Enums;
using MazeGame.Models;

namespace MazeGame.Builders;

public class RoomBuilder
{
    private Room _room = new();


    public RoomBuilder TypeOf(RoomType roomType)
    {
        _room.RoomType = roomType;
        return this;
    }

    public RoomBuilder WithWalls(List<Wall> walls)
    {
        _room.Walls = walls;
        return this;
    }

    public RoomBuilder WithScenery(Scenery scenery)
    {
        _room.Scenery = scenery;
        return this;
    }

    public Room Build()
    {
        var result = _room;
        _room = new Room();
        return result;
    }

}
