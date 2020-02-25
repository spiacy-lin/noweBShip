using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noweBShip
{
    class Battleship: Ship
    {
        public Battleship()
        {
            Name = "BATTLESHIP";
            Width = 4;
            Cover = new List<string>(); 
        }
        public override void ManFillCover()
        {
            string[] strcover = new string[4];
            Console.WriteLine("Enter BATTLESHIP occupied coords (ex. B1,B2,B3,B4):");
            string c = Console.ReadLine();
            strcover = c.Split(",", 4, StringSplitOptions.RemoveEmptyEntries);
            Cover = strcover.OfType<string>().ToList();
        }
        public override void AutoFillCover()
        {
            
        }
    }
}