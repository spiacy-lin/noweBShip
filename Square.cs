using System;
using System.Collections.Generic;
using System.Text;

namespace noweBShip 
{
    class Square 
	{
    	private Square.Mark Front;  // front mark of an instance of class Square
		private Square.Mark Back;  // back mark of an instance of class Square
		private Square.Mark Available;  // helping info to replace ship on board
		public enum Mark {CARRIER, BATTLESHIP, CRUISER,  SUBMARINE, DESTROYER, WATER, MISSED, HIT, NOT_SET, SUNK}
		
		// class method to switch sides of square (up <=> down)
		public void upsideDown()
		{
			var temp = this.Front;
			this.Front = this.Back;
			this.Back = temp;
		}
		// class method to set mark on front (visible) side
		public void SetFront(Square.Mark value)
		{
			this.Front = value;
		}
		// class method to set mark on back (unvisible) side
		public void SetBack(Square.Mark value)
		{
			this.Back = value;
		}
		
		// method to check is square is available (not_set) : helful to replace ships
		public bool IsAvailable()
		{
			return this.Available == Mark.NOT_SET;
		}
		public Square.Mark GetFront()
		{
			return Front;
		}
	}
}
