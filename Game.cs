using System;
using System.Collections.Generic;
using System.Text;

namespace noweBShip
{
    class Game
    {
        private Random random = new Random();
        public void StartGame()
        {
            Console.WriteLine("Player vs. AI battleship game");
            Ocean EnOcean = new Ocean();
		    Ocean MyOcean = new Ocean();
            ShipsLocation EnLocation = new ShipsLocation();
            ShipsLocation MyLocation = new ShipsLocation();
            
            // initial fillup of enemy and my Ocean(Squeres)
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    EnOcean.Board[i,j].SetFront(Square.Mark.WATER);
                    EnOcean.Board[i,j].SetBack(Square.Mark.MISSED);
                    MyOcean.Board[i,j].SetFront(Square.Mark.WATER);
                    MyOcean.Board[i,j].SetBack(Square.Mark.MISSED);
                }
            }
            /*
            // placement enemy ships in Ships (List)
            Console.WriteLine("If manualy placement of enemy ships - press Y:");
            string choice = Console.ReadLine();
            if (choice == "Y")
            {
                foreach (Ship item in EnLocation.Ships)
                {
                    item.ManFillCover();
                }
            }
            else
            {
                foreach (Ship item in EnLocation.Ships)
                {
                    item.AutoFillCover();
                }
            }

            // placement my ships in Ships(List)
            Console.WriteLine("If manualy placement of my ships - press Y:");
            string choice1 = Console.ReadLine();
            if (choice1 == "Y")
            {
                foreach (Ship item in MyLocation.Ships)
                {
                    item.ManFillCover();
                }
            }
            else
            {
                foreach (Ship item in MyLocation.Ships)
                {
                    item.AutoFillCover();
                }
            }*/
            Console.WriteLine("The game preparation time is over. Press any button to start battle");
            Console.ReadKey();
            Console.Clear();
            DisplayTwoBoards(EnOcean.Board, MyOcean.Board);

            // Blok Łukasza
            // w pętli while - aż ktoś wygra (na razie ustaw na 20 ruchów, chodzi o zasada
            // ruch gracza z klawiatury - przekrętka Square Front/Back na enemy Ocean
            // ruch AI z wymyślonej strategii - przekrętka Square Front na my Ocean
            // odświeżenie Console.Clear()
            // DisplayTwoBoards(...)

            

		}
        //Display two boards in terminal
        static void DisplayTwoBoards(Square[,] en, Square[,] my)
        {
            Console.WriteLine("       ENEMY OCEAN                 MY OCEAN");
            Console.WriteLine("   0 1 2 3 4 5 6 7 8 9        0 1 2 3 4 5 6 7 8 9  ");
            Console.WriteLine("  |------------------- |     |--------------------|");
            string line1 = "";
            string line2 = "";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // put appropriate char to front - enemy
                    string e = en[i,j].GetFront().ToString();
                    if (e == "CARRIER")
                    {
                        line1 += "A ";
                    }
                    else if (e == "BATTLESHIP")
                    {
                        line1 += "B ";
                    }
                    else if (e == "CRUISER")
                    {
                        line1 += "C ";
                    }
                    else if (e == "SUBMARINE")
                    {
                        line1 += "S ";
                    }
                    else if (e == "DESTROYER")
                    {
                        line1 += "D ";
                    }
                    else if (e == "WATER")
                    {
                        line1 += "~ ";
                    }
                    else if (e == "MISSED")
                    {
                        line1 += "o ";
                    }
                    else if (e == "HIT")
                    {
                        line1 += "X ";
                    }
                    else
                    {
                        line1 += "?";
                    }
                    // put appropriate char to front - my
                    string m = my[i,j].GetFront().ToString();
                    if (m == "CARRIER")
                    {
                        line2 += "A ";
                    }
                    else if (m == "BATTLESHIP")
                    {
                        line2 += "B ";
                    }
                    else if (m == "CRUISER")
                    {
                        line2 += "C ";
                    }
                    else if (m == "SUBMARINE")
                    {
                        line2 += "S ";
                    }
                    else if (m == "DESTROYER")
                    {
                        line2 += "D ";
                    }
                    else if (m == "WATER")
                    {
                        line2 += "~ ";
                    }
                    else if (m == "MISSED")
                    {
                        line2 += "o ";
                    }
                    else if (m == "HIT")
                    {
                        line2 += "X ";
                    }
                    else
                    {
                        line2 += "?";
                    }
                }
                Console.Write("{0}", (char)(65+i));
                Console.WriteLine(" |" + line1 + "|     |" + line2 + "| ");
                line1 = "";
                line2 = "";
            }
            Console.WriteLine("  |--------------------|     |--------------------|");
        }
    }
}
