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
    }
}