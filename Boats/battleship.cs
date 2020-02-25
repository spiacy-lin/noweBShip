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
    }
}