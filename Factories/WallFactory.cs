using MazeGame.Builders;
using MazeGame.Enums;
using MazeGame.Models;

namespace MazeGame.Factories;

public class WallFactory
{
    private readonly DataRepository _db = new DataRepository();
    private readonly Random rnd = new Random();

    public List<Wall> MonsterRoomWalls()
    {
        var wallTypes = RandomWallTypes(WallType.Monster);
        var walls = GenerateWalls(wallTypes);
        return walls;
    }

    public List<Wall> TreasureRoomWalls()
    {
        var wallTypes = RandomWallTypes(WallType.Treasure);
        var walls = GenerateWalls(wallTypes);
        return walls;
    }

    public List<Wall> RegularRoomWalls()
    {
        var wallTypes = RandomWallTypes();
        var walls = GenerateWalls(wallTypes);
        return walls;
    }


    private Queue<WallType> RandomWallTypes(WallType typeToAdd = WallType.Door)
    {
        var wallTypes = new List<WallType> { WallType.Door, typeToAdd };

        for (int i = 0; i < 2; i++)
        {
            var rndNum = rnd.Next(10);
            wallTypes.Add(rndNum <= 5 ? WallType.Door : WallType.Empty);
        }

        return new Queue<WallType>(wallTypes.OrderBy(x => rnd.Next()));
    }

    private List<Wall> GenerateWalls(Queue<WallType> wallTypes)
    {
        var walls = new List<Wall>();
        foreach (var dir in Enum.GetValues<Direction>())
        {
            var wallType = wallTypes.Dequeue();

            var wallBuilder = new WallBuilder()
                .WithType(wallType)
                .WithDirection(dir);

            switch (wallType)
            {
                case WallType.Monster:
                    wallBuilder
                        .WithMonster(_db.GetMonster())
                        .WithView(_db.GetMonsterWallView());
                    break;

                case WallType.Treasure:
                    wallBuilder
                        .WithTreasure(_db.GetTreasure())
                        .WithView(_db.GetTreasureWallView());
                    break;

                case WallType.Door:
                    wallBuilder
                        .WithView(_db.GetDoorWallView());
                    break;

                default:
                    wallBuilder
                        .WithView(_db.GetEmptyWallView());
                    break;
            }

            walls.Add(wallBuilder.Build());
        }

        return walls;
    }
}
