using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noweBShip
{
    class Destroyer: Ship
    {
        public Destroyer()
        {
            Name = "DESTROYER";
            Width = 2;
            Cover = new List<string>();
        }
        public override void ManFillCover()
        {
            string[] strcover = new string[2];
            Console.WriteLine("Enter DESTROYER occupied coords (ex. B1,B2):");
            string c = Console.ReadLine();
            strcover = c.Split(",", 2, StringSplitOptions.RemoveEmptyEntries);
            Cover = strcover.OfType<string>().ToList();
        }
        public override void AutoFillCover()
        {
            
        }
    }
}