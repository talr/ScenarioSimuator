using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorNamespace
{
    class GameObject
    {
        #region Properties
        Vector2 Position;
        string Name;
        #endregion

        #region Constructors
        public GameObject(string Name)
        {
            this.Name = Name;
            Position = new Vector2();
        }
        public GameObject(string Name, Vector2 Position)
        {
            this.Name = Name;
            this.Position = Position;
        }

        public GameObject()
        {
            Name = "";
            Position = new Vector2();
        }
        #endregion
    }
}
