using System;
using System.Collections.Generic;
using System.Text;

namespace noweBShip 
{
    
    public class ShipsLocation
    {
        public List<Ship> Ships { get; set; }
        public bool [,] Plansza = new bool[10,10];
        public ShipsLocation()
        {
            Ships = new List<Ship>();
            Ship aircar = new Carrier();
            Ships.Add(aircar);
            Ship batship = new Battleship();
            Ships.Add(batship);
            Ship cruis = new Cruiser();
            Ships.Add(cruis);
            Ship submar = new Submarine();
            Ships.Add(submar);
            Ship destr = new Destroyer();
            Ships.Add(destr);
        }
        
    }
}
