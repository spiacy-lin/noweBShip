using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noweBShip
{
    class Carrier: Ship
    {
        public Carrier()
        {
            Name = "CARRIER";
            Width = 5;
            Cover = new List<string>(); 
        }
        public override void ManFillCover()
        {
            string[] strcover = new string[5];
            Console.WriteLine("Enter CARRIER occupied coords (ex. B1,B2,B3,B4,B5):");
            string c = Console.ReadLine().ToUpper();
            strcover = c.Split(",", 5, StringSplitOptions.RemoveEmptyEntries);
            Cover = strcover.OfType<string>().ToList();
        }
        public override void AutoFillCover()
        {
            
        }
    }
}