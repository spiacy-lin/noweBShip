using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noweBShip
{
    class Cruiser: Ship
    {
        public Cruiser()
        {
            Name = "CRUISER";
            Width = 3;
            Cover = new List<string>(); 
        }
    }
}