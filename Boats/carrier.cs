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
            string c = Console.ReadLine();
            strcover = c.Split(",", 5, StringSplitOptions.RemoveEmptyEntries);
            Cover = strcover.OfType<string>().ToList();
        }
        public override void AutoFillCover()
        {
            /*bool end = true;
            while (end)
            {
                int orientation = random.Next(2);
                int x = random.Next(10);
                int y = random.Next(10);
                if (orientation == 0)  // horizontal
                {
                    
                    if (y >= 6) break; //sprawdzamy czy się mieści na planszy
                    for (int i = y; i < y + 5; i++)  //sprawdzamy czy jest dostepny
                    {
                        if ()
                    }

                }
                else                    //vertical
                {

                }
            }*/
            
        }    
    }
}