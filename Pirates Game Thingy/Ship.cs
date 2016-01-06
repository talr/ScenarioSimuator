using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorNamespace
{
    class Ship : GameObject
    {
        Vector2 Position;
        Player Owner;
        int Speed;
        Vector2 nextDisplacement;

        //Constructor
        public Ship(Player Player, int Speed, Vector2 pos)
        {
            Position = pos;
            Owner = Player;
            this.Speed = Speed;
            nextDisplacement = new Vector2(0, 0);
        }

        //Get Set
        public Vector2 GetPosition()
        {
            return Position;
        }

        public int GetSpeed()
        {
            return Speed;
        }

        public Vector2 GetNextDisplacememt()
        {
            return nextDisplacement;
        }

        public void SetPosition(Vector2 NewPosition)
        {
            Position = NewPosition;
        }

        public void SetDisplacement(Vector2 dis)
        {
            nextDisplacement = dis;
        }
    }
}
