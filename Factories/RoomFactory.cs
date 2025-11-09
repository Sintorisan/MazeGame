
using MazeGame.Builders;
using MazeGame.Enums;
using MazeGame.Models;

namespace MazeGame.Factories;

public class RoomFactory
{
    private readonly DataRepository _db;
    public RoomFactory()
    {
        _db = new DataRepository();
    }
    public Room MonsterRoom()
    {
        List<Wall> walls = new WallFactory().MonsterRoomWalls();

        var roomType = RoomType.MonsterRoom;
        var scenery = _db.GetScenery(roomType);

        return new RoomBuilder()
                .TypeOf(roomType)
                .WithWalls(walls)
                .WithScenery(scenery)
                .Build();
    }

    public Room RegularRoom()
    {
        List<Wall> walls = new WallFactory().RegularRoomWalls();

        var roomType = RoomType.RegularRoom;
        var scenery = _db.GetScenery(roomType);

        return new RoomBuilder()
                .TypeOf(roomType)
                .WithWalls(walls)
                .WithScenery(scenery)
                .Build();
    }

    public Room TreasureRoom()
    {
        List<Wall> walls = new WallFactory().TreasureRoomWalls();

        var roomType = RoomType.TreasureRoom;
        var scenery = _db.GetScenery(roomType);

        return new RoomBuilder()
                .TypeOf(roomType)
                .WithWalls(walls)
                .WithScenery(scenery)
                .Build();
    }

    public Room ConnectorRoom(Direction entryDir)
    {
        var room = RegularRoom();

        foreach (var w in room.Walls)
            w.WallType = WallType.Empty;

        var entryWall = room.Walls.First(w => w.Direction == entryDir);
        entryWall.WallType = WallType.Door;
        entryWall.IsPassable = true;

        return room;
    }

}
