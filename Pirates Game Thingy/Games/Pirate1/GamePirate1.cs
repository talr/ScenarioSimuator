using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimulatorNamespace
{
    class GamePirate1:Game
    {
        #region Properties
        World world;
        List<Player> Players;
        Player Winner;
        int NumberOfTurns;
        //int NumberOfShips;
        //int NumberOfIslands;
        int NumberOfIslandsToWin;
        //int CurrentTurnNumber;
        #endregion
        #region Constructors
        public GamePirate1(int NumberOfIslands, int NumberOfIslandsToWin, Vector2[] IslandPositions)
        {
            world = CreateWorld(NumberOfIslands, IslandPositions);
            Players = new List<Player>();
            NumberOfTurns = 0;
            this.NumberOfIslandsToWin = NumberOfIslandsToWin;
        }

        public GamePirate1(World World, List<Player> Players)
        {
            world = World;
            this.Players = Players;
            NumberOfTurns = 0;

        }

        public GamePirate1(List<Island> Islands, List<Player> Players)
        {
            List<Ship> Ships = new List<Ship>();
            for (int PlayerIndex = 0; PlayerIndex < Players.Count; PlayerIndex++)
            {
                for (int ShipIndex = 0; ShipIndex < Players[PlayerIndex].GetShips().Count; ShipIndex++)
                {
                    Ships.Add(Players[PlayerIndex].GetShips()[ShipIndex]);
                }
            }
            World World = new World(Islands);
            NumberOfTurns = 0;
        }
        #endregion
        #region GetSet
        public List<Player> GetPlayers()
        {
            return Players;
        }
        public Player GetPlayer(int playerNum)
        {
            if (Players.Count > 0 && playerNum < Players.Count)
                return Players[playerNum];
            return null;
        }

        public World GetWorld()
        {
            return world;
        }
        #endregion
        #region Methods
        public void StartGame()
        {
            DisplayStats();
            DisplayWorld();
            while (Winner == null)
            {
                Turn();
                DisplayStats();
                DisplayWorld();
                Console.ReadLine();
            }
        }
        public void Turn()
        {
            List<Island> islands = world.GetIslands();
            for (int PlayerIndex = 0; PlayerIndex < Players.Count; PlayerIndex++)
            {
                Players[PlayerIndex].WhatDo(this);
            }
            NumberOfTurns++;
            for (int PlayerIndex = 0; PlayerIndex < Players.Count; PlayerIndex++)
            {
                for (int shipIndex = 0; shipIndex < Players[PlayerIndex].GetShips().Count; shipIndex++)
                {
                    Ship ship = Players[PlayerIndex].GetShip(shipIndex);
                    ship.SetPosition(ship.GetPosition() + ship.GetNextDisplacememt());
                }
            }

            for (int isladsIndex = 0; isladsIndex < islands.Count; isladsIndex++)
            {
                CheckIslandOwner(islands[isladsIndex]);
            }
            int win = CheckWinner();
            if (win > -1)
                Winner = Players[win];
        }
        public void DisplayStats()
        {
            for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
            {
                Console.ForegroundColor = GetColor(playerIndex);
                Console.WriteLine(GetPlayer(playerIndex).GetName() + ":");
                Console.WriteLine("Points: " + GetPlayer(playerIndex).GetPoints());
                Console.WriteLine("Number of islands in possession: " + GetPlayer(playerIndex).GetNumberOfIslands());
                Console.WriteLine("Ships positions:");
                for (int shipIndex = 0; shipIndex < GetPlayer(playerIndex).GetShips().Count; shipIndex++)
                {
                    int islandNumber = -1;
                    Vector2 Position = GetPlayer(playerIndex).GetShips()[shipIndex].GetPosition();
                    for (int islandIndex = 0; islandIndex < world.GetIslands().Count; islandIndex++)
                    {
                        if (Position == world.GetIslands()[islandIndex].GetPosition())
                            islandNumber = islandIndex;


                    }
                    Console.WriteLine("Ship " + shipIndex + ":");
                    Console.Write("Position: " + Position);
                    if (islandNumber > -1)
                    {
                        Console.WriteLine("(Island: " + islandNumber + ")");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }
            if (Winner != null)
            {
                Console.WriteLine("WINNER: " + Winner.GetName());
            }
        }
        public void DisplayWorld()
        {
            List<Island> islands = world.GetIslands();
            double minX = 0, maxX = 0, minY = 0, maxY = 0;
            for (int islandIndex = 0; islandIndex < islands.Count; islandIndex++)
            {
                minX = Math.Min(minX, islands[islandIndex].GetPosition().x);
                maxX = Math.Max(maxX, islands[islandIndex].GetPosition().x);
                minY = Math.Min(minY, islands[islandIndex].GetPosition().y);
                maxY = Math.Max(minY, islands[islandIndex].GetPosition().y);
            }
            for (int Y = (int)Math.Ceiling(maxY) + 5; Y >= (int)Math.Floor(minY) - 5; Y--)
            {
                for (int X = (int)Math.Floor(minX) - 5; X <= (int)Math.Ceiling(maxX) + 5; X++)
                {
                    int shipPlayer = -1;
                    bool multShip = false;
                    int island = -1;
                    for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
                    {
                        List<Ship> ships = Players[playerIndex].GetShips();
                        for (int shipIndex = 0; shipIndex < ships.Count; shipIndex++)
                        {
                            if (ships[shipIndex].GetPosition().Round() == new Vector2(X, Y))
                            {
                                if ((shipPlayer != -1) && (shipPlayer != playerIndex))
                                    multShip = true;
                                shipPlayer = playerIndex;
                            }
                        }
                    }
                    for (int islandIndex = 0; islandIndex < islands.Count; islandIndex++)
                    {
                        if (islands[islandIndex].GetPosition().Round() == new Vector2(X, Y))
                            island = islandIndex;
                    }
                    if ((island == -1) && (shipPlayer == -1))
                        Console.Write(" ");
                    else if ((island != -1) && (shipPlayer == -1))
                    {
                        Console.ForegroundColor = GetColor(islands[island].GetControllingPlayerNumber());
                        Console.Write("@");
                    }
                    else if ((island == -1) && (shipPlayer != -1))
                    {
                        Console.ForegroundColor = GetColor(shipPlayer);
                        if (multShip == true)
                            Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("$");
                    }
                    else if ((island != -1) && (shipPlayer != -1))
                    {
                        Console.ForegroundColor = GetColor(islands[island].GetControllingPlayerNumber());
                        Console.Write("&");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("___________________");
            if (Winner != null)
            {
                Console.WriteLine("WINNER: " + Winner.GetName());
            }
        }
        public ConsoleColor GetColor(int colorNumber)
        {
            ConsoleColor returnedColor = ConsoleColor.White; //default is white
            switch (colorNumber)
            {
                case 0:
                    {
                        returnedColor = ConsoleColor.Yellow;
                        break;
                    }
                case 1:
                    {
                        returnedColor = ConsoleColor.Cyan;
                        break;
                    }
                case 2:
                    {
                        returnedColor = ConsoleColor.Green;
                        break;
                    }
                case 3:
                    {
                        returnedColor = ConsoleColor.Red;
                        break;
                    }
                case 4:
                    {
                        returnedColor = ConsoleColor.Magenta;
                        break;
                    }
                case 5:
                    {
                        returnedColor = ConsoleColor.Blue;
                        break;
                    }
            }
            return returnedColor;
        }

        public void CheckIslandOwner(Island island)
        {
            int numOfOwnerShips = 0;
            int owner = -1;
            for (int PlayerIndex = 0; PlayerIndex < Players.Count; PlayerIndex++)
            {
                int numOfShips = 0;
                List<Ship> ships = Players[PlayerIndex].GetShips();
                for (int ShipIndex = 0; ShipIndex < ships.Count; ShipIndex++)
                {
                    if (ships[ShipIndex].GetPosition() == island.GetPosition())
                        numOfShips++;
                }
                if (numOfShips > numOfOwnerShips)
                {
                    numOfOwnerShips = numOfShips;
                    owner = PlayerIndex;
                }
                else if ((numOfShips == numOfOwnerShips) && (numOfOwnerShips > 0))
                {
                    owner = -1;
                    PlayerIndex = Players.Count;
                }
            }
            if (owner != -1)
            {
                if ((island.GetControllingPlayerNumber() != owner) && (island.GetControllingPlayerNumber() > -1))
                    Players[island.GetControllingPlayerNumber()].RemoveIsland();
                else if (island.GetControllingPlayerNumber() != owner)
                {
                    island.SetControl(owner);
                    Players[owner].AddPoints(10);
                    Players[owner].AddIsland();
                }
            }
            else
            {
                if (island.GetControllingPlayerNumber() > -1)
                    Players[island.GetControllingPlayerNumber()].RemoveIsland();
                island.SetControl(-1);
            }
        }
        public int CheckWinner()
        {
            int winnerNumberOfIslands = 0;
            int win = -1;
            bool draw = false;
            for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++)
            {
                int numberOfIslands = Players[playerIndex].GetNumberOfIslands();
                if (numberOfIslands >= NumberOfIslandsToWin)
                    if (numberOfIslands > winnerNumberOfIslands)
                    {
                        winnerNumberOfIslands = numberOfIslands;
                        win = playerIndex;
                    }
                    else if (numberOfIslands == winnerNumberOfIslands)
                        draw = true;
            }
            if (draw == true)
                return -1;
            return win;
        }

        public void AddPlayer(Player Player)
        {
            Players.Add(Player);
        }
        #endregion
        #region CreateStuff
        public World CreateWorld(int NumberOfIslands, Vector2[] Positions)
        {
            List<Island> Islands = new List<Island>();
            for (int IslandIndex = 0; IslandIndex < NumberOfIslands; IslandIndex++)
            {
                Islands.Add(CreateIsland(Positions[IslandIndex]));
            }
            World World = new World(Islands);
            return World;
        }

        public Island CreateIsland(Vector2 Position)
        {
            Island Island = new Island(Position);
            return Island;
        }
        #endregion

    }
}
