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
    }
}