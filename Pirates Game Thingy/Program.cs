using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2[] IslandPositions = new Vector2[5];
            IslandPositions[0] = new Vector2(-10, -10);
            IslandPositions[1] = new Vector2(10, -10);
            IslandPositions[2] = new Vector2(0, 0);
            IslandPositions[3] = new Vector2(-10, 10);
            IslandPositions[4] = new Vector2(10, 10);
            GamePirate1 game = new GamePirate1(5, 3, IslandPositions);
            Player moshe = new Moshe("Moshe", 0, IslandPositions[0], 6);
            Player moMoshe = new MoMoshe("MoMoshe", 1, IslandPositions[4], 6);
            game.AddPlayer(moshe);
            game.AddPlayer(moMoshe);
            game.GetWorld().GetIsland(0).SetControl(0);
            game.GetWorld().GetIsland(4).SetControl(1);
            game.StartGame();
        }
    }
}
