using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorNamespace
{
    class MoMoshe:Player
    {
        public MoMoshe(string Name, int Number, Vector2 baseIsland, int NumberOfShips)
            : base(Name, Number, baseIsland, NumberOfShips)
        {
        }

        public override void WhatDo(GamePirate1 Game)
        {
            List<Island> Islands = Game.GetWorld().GetIslands();
            for (int shipIndex = 0; shipIndex < base.GetShips().Count; shipIndex++)
            {
                if (shipIndex < Islands.Count)
                    MoveShip(shipIndex, Islands[shipIndex].GetPosition());
            }
        }
    }
}
