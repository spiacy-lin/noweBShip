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
            
            Console.WriteLine("If manualy placement of enemy ships - press Y:");
            string choice = Console.ReadLine();
            if (choice == "Y")
            {
                foreach (Ship item in EnLocation.Ships)
                {
                    item.ManFillCover();
                }
            }
            else
            {
                foreach (Ship item in EnLocation.Ships)
                {
                    item.AutoFillCover();
                }
            }

            // placement my ships in Ships(List)
            Console.WriteLine("If manualy placement of my ships - press Y:");
            string choice1 = Console.ReadLine();
            if (choice1 == "Y")
            {
                foreach (Ship item in MyLocation.Ships)
                {
                    item.ManFillCover();
                }
            }
            else
            {
                foreach (Ship item in MyLocation.Ships)
                {
                    item.AutoFillCover();
                }
            }
		}


    }
}
