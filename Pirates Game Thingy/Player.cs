using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorNamespace
{
    class Player
    {
        #region Properties
        string Name;
        int Number;
        int NumberOfShips;
        int NumberOfIslandsInPossession;
        int Points;
        List<Ship> Ships;
        #endregion
        #region Constructors
        public Player(string Name, int Number, Vector2 baseIsland, int NumberOfShips)
        {
            this.Name = Name;
            Ships = new List<Ship>();
            this.NumberOfShips = NumberOfShips;
            CreateShips(NumberOfShips, baseIsland);
            this.Number = Number;
            NumberOfIslandsInPossession = 0;
        }
        public Player(int Number)
        {
            Name = "Player" + Number;
            Ships = new List<Ship>();
            NumberOfShips = 0;
            this.Number = Number;
            NumberOfIslandsInPossession = 0;
        }
        #endregion
        #region GetSet

        public int GetPoints()
        {
            return Points;
        }
        public int GetPlayerNumber()
        {
            return Number;
        }
        public List<Ship> GetShips()
        {
            return Ships;
        }



        public Ship GetShip(int ShipNumber)
        {
            
                return Ships[ShipNumber];
        }



        public static int GetNumberOfShips(GamePirate1 game, int playerNum)
        {
            return game.GetPlayer(playerNum).GetShips().Count;
        }

        public string GetName()
        {
            return Name;
        }

        public double GetDistanceBetweenShipAndIsland(Player Player, int ShipNumber, int IslandNumber, World world)
        {
            Ship Ship = Player.GetShip(ShipNumber);
            Island Island = world.GetIsland(IslandNumber);
            Vector2 ShipPosition = Ship.GetPosition();
            Vector2 IslandPosition = Island.GetPosition();
            double Distance = ShipPosition.Distance(IslandPosition);
            return Distance;
        }

        public int GetNumberOfIslands()
        {
            if (this == null)
                return 0;
            return NumberOfIslandsInPossession;
        }

        #endregion
        #region Methods
        public void CreateShips(int numberOfShips, Vector2 baseIsland)
        {
            for (int shipIndex = 0; shipIndex < numberOfShips; shipIndex++)
            {
                Ships.Add(new Ship(this, 1, baseIsland));
            }
        }


        protected static Vector2 GetIslandPosition(World world, int islandNum)
        {
            return world.GetIsland(islandNum).GetPosition();
        }
        protected static Vector2 GetShipPosition(GamePirate1 game, int playerNum, int shipNum)
        {
            return game.GetPlayer(playerNum).GetShip(shipNum).GetPosition();
        }

        protected void MoveShip(int shipNum, Vector2 newPos)
        {
            Ship ship = Ships[shipNum];
            Vector2 oldPos = ship.GetPosition();
            Vector2 displacement = newPos - oldPos;
            if (displacement.Length() > ship.GetSpeed())
                displacement = ship.GetSpeed() * (displacement / displacement.Length());
            ship.SetDisplacement(displacement);
        }
        protected static double Distance(Vector2 p1, Vector2 p2)
        {
            return (p2 - p1).Length();
        }
        public void AddIsland()
        {
            NumberOfIslandsInPossession++;
        }
        public void RemoveIsland()
        {
            if (NumberOfIslandsInPossession > 0)
                NumberOfIslandsInPossession--;

        }
        public void AddPoints(int NumberOfPoints)
        {
            Points += NumberOfPoints;
        }
        #endregion
        public virtual void WhatDo(GamePirate1 Game) { }





    }
}