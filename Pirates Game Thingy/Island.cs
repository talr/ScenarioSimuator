using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorNamespace
{
    class Island:GameObject
    {
        #region Properties
        Vector2 Position;
       // int Number;
        List<Ship> ShipsOnIsland;
        int ControllingPlayerNumber;
        #endregion
        #region Constructors
        public Island(Vector2 Position, int ControllingPlayerNumber)
        {
            ShipsOnIsland = new List<Ship>();
         //   Number = World.GetNumberOfIslands() + 1;
            this.Position = Position;
            this.ControllingPlayerNumber = ControllingPlayerNumber;
        }

        public Island(Vector2 Position)
        {
            ShipsOnIsland = new List<Ship>();
         //   Number = World.GetNumberOfIslands() + 1;
            this.Position = Position;
            ControllingPlayerNumber = -1;
        }
        #endregion
        #region GetSet
        public Vector2 GetPosition()
        {
            return Position;
        }

        //public int GetNumber()
        //{
        //    return Number;
        //}

        public List<Ship> GetShipsOnIsland()
        {
            return ShipsOnIsland;
        }

        public int GetControllingPlayerNumber()
        {
            return ControllingPlayerNumber;
        }

        public void SetControl(int PlayerNumber)
        {
            ControllingPlayerNumber = PlayerNumber;
        }

        public void RemoveControl()
        {
            ControllingPlayerNumber = -1;
        }
        #endregion
    }
}
