using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorNamespace
{
    class World
    {
        #region Properties
        List<Island> Islands;
        #endregion
        #region Constructors
        public World()
        {
            Islands = new List<Island>();
        }

        public World(List<Island> Islands)
        {
            this.Islands = Islands;
        }
        #endregion
        #region GetSet
        public List<Island> GetIslands()
        {
            return Islands;
        }
        public Island GetIsland(int IslandNumber)
        {
            if (Islands.Count > 0 && IslandNumber < Islands.Count)
                return Islands[IslandNumber];
            return null;
        }
        #endregion
        #region Methods
        public void AddIsland(Island Island)
        {
            Islands.Add(Island);
        }
        #endregion

    }
}
