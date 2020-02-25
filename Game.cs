using System;
using System.Collections.Generic;
using System.Text;

namespace noweBShip
{
    class Game
    {
        private Random random = new Random();
        public void StartGame()
        {
            Console.WriteLine("Player vs. AI battleship game");
            Ocean EnOcean = new Ocean();
		    Ocean MyOcean = new Ocean();
            ShipsLocation EnLocation = new ShipsLocation();
            ShipsLocation MyLocation = new ShipsLocation();
            // placement enemy ships in Ships (List)
            foreach (Ship item in EnLocation.Ships)
            {
                string type = item.Name;
                if (type == "CARRIER")
                {
                    item.Cover[0] = ""
                } 
            }
		}


    }
}
