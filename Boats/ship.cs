using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noweBShip
{
    public abstract class Ship
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public List<string> Cover {get; set;}
        public abstract void ManFillCover();
        public abstract void AutoFillCover();
        
    }

}