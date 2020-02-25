using System;
using System.Collections.Generic;
using System.Text;

namespace noweBShip 
{
    class Ocean 
	{
    	
		public Square[,] Board = new Square[10,10];
		public Ocean()
		{
			for(int x = 0; x<10; x++)
			{
				for(int y = 0; y<10; y++)
				{
					Board[x,y] = new Square();
				}
			}
		}
		
	}
}
