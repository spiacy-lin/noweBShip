using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace noweBShip
{
    class Submarine: Ship
    {
        public Submarine()
        {
            Name = "SUBMARINE";
            Width = 2;
            Cover = new List<string>(); 
        }
        public override void ManFillCover()
        {
            string[] strcover = new string[3];
            Console.WriteLine("Enter SABMARINE occupied coords (ex. B1,B2):");
            string c = Console.ReadLine();
            strcover = c.Split(",", 2, StringSplitOptions.RemoveEmptyEntries);
            Cover = strcover.OfType<string>().ToList();
        }
        public override void AutoFillCover()
        {
            
        }
    }
}