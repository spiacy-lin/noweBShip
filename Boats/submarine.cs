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
            Width = 3;
            Cover = new List<string>(); 
        }
    }
}