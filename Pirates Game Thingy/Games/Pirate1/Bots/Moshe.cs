using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorNamespace
{
    class Moshe:Player
    {
        public Moshe(string Name, int Number, Vector2 baseIsland, int NumberOfShips)
            : base(Name, Number, baseIsland, NumberOfShips)
        {
        }
        public override void WhatDo(GamePirate1 Game)
        {
            List<Island> Islands = Game.GetWorld().GetIslands();
            List<Ship> ships = base.GetShips();
            for (int shipIndex = 0; shipIndex < base.GetShips().Count; shipIndex++)
            {
                MoveShip(shipIndex, new Vector2(0, 0));
            }
        }
    }
}
