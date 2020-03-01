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
            
            // fillup contenents of cover in enemy ships /before empty list
            Console.WriteLine("Would you like to manualy place enemy ships - press Y:");
            string choice = Console.ReadLine().ToUpper();
            if (choice == "Y")
            {
                foreach (Ship item in EnLocation.Ships)
                {
                    item.ManFillCover();
                    
                }
                PlaceShipE(EnLocation, EnOcean);
            }
            else
            {
               AutoPlacement(EnLocation);
               PlaceShipE(EnLocation, EnOcean); 
            }
                        
            // fillup contenents of cover in my ships /before empty list
            Console.WriteLine("Would you like to manualy place your ships - press Y:");
            string choice1 = Console.ReadLine().ToUpper();
            if (choice1 == "Y")
            {
                foreach (Ship item in MyLocation.Ships)
                {
                    item.ManFillCover();
                }
                PlaceShipM(MyLocation, MyOcean);
            }
            else
            {
                AutoPlacement(MyLocation);
                PlaceShipM(MyLocation, MyOcean);
            }
            
            Console.WriteLine("The game preparation time is over. Press any button to start battle");
            Console.ReadKey();
            
            // GAME FLOW
            Console.Clear();
            Console.WriteLine("         Player vs. AI battleship game");
            Console.WriteLine();
            DisplayTwoBoards(EnOcean.Board, MyOcean.Board);
            Console.WriteLine();
            
            // Plansza will be used during game to avoid hit in the same coord i for AI
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    EnLocation.Plansza[i,j] = false;
                    MyLocation.Plansza[i,j] = false;
                }
            }
            
            int myHits = 0;
            int enemyHits = 0;
            bool nextTurn = true;
            while(nextTurn)
            {
                // my turn
                Console.Write("Enter hit coordinates (ex. D5): ");
                string inputCoord = Console.ReadLine().ToUpper();
                Char srow = inputCoord[0];
                int x = 0;
                if (srow == 'A'){x = 0;}
                else if (srow == 'B') {x = 1;}
                else if (srow == 'C') {x = 2;}
                else if (srow == 'D') {x = 3;}
                else if (srow == 'E') {x = 4;}
                else if (srow == 'F') {x = 5;}
                else if (srow == 'G') {x = 6;}
                else if (srow == 'H') {x = 7;}
                else if (srow == 'I') {x = 8;}
                else if (srow == 'J') {x = 9;}
                Char scol= inputCoord[1];
                int y = scol - '0';
                if (!EnLocation.Plansza[x,y])
                {
                    EnOcean.Board[x,y].upsideDown();  //przewrotka
                    EnLocation.Plansza[x,y] = true;
                                    
                    if (EnOcean.Board[x,y].GetFront()== Square.Mark.CARRIER)
                    {
                        Console.WriteLine("You hit Air-Carrier");
                        EnLocation.Ships[0].Width--;
                        if (EnLocation.Ships[0].Width==0) 
                        {
                            Console.WriteLine("Air-Carrier is sunken");
                            foreach (string item in EnLocation.Ships[0].Cover)
                            {
                                int a = Transformacja2(item[0]);
                                int b = Transformacja3(item[1]);
                                EnOcean.Board[a,b].SetFront(Square.Mark.SUNK);
                            }

                        }
                        System.Threading.Thread.Sleep(2000);
                        myHits++;
                    }
                    else if (EnOcean.Board[x,y].GetFront()== Square.Mark.BATTLESHIP)
                    {
                        Console.WriteLine("You hit Battleship");
                        EnLocation.Ships[1].Width--;
                        if (EnLocation.Ships[1].Width==0) 
                        {
                            Console.WriteLine("Battleship is sunken");
                            foreach (string item in EnLocation.Ships[1].Cover)
                            {
                                int a = Transformacja2(item[0]);
                                int b = Transformacja3(item[1]);
                                EnOcean.Board[a,b].SetFront(Square.Mark.SUNK);
                            }
                        }
                        System.Threading.Thread.Sleep(2000);
                        myHits++;
                    }
                    else if (EnOcean.Board[x,y].GetFront()== Square.Mark.CRUISER)
                    {
                        Console.WriteLine("You hit Cruiser");
                        EnLocation.Ships[2].Width--;
                        if (EnLocation.Ships[2].Width==0) 
                        {
                            Console.WriteLine("Cruiser is sunken");
                            foreach (string item in EnLocation.Ships[2].Cover)
                            {
                                int a = Transformacja2(item[0]);
                                int b = Transformacja3(item[1]);
                                EnOcean.Board[a,b].SetFront(Square.Mark.SUNK);
                            }
                        }
                        System.Threading.Thread.Sleep(2000);
                        myHits++;
                    }
                    else if (EnOcean.Board[x,y].GetFront()== Square.Mark.SUBMARINE)
                    {
                        Console.WriteLine("You hit Submarine");
                        EnLocation.Ships[3].Width--;
                        if (EnLocation.Ships[3].Width==0) 
                        {
                            Console.WriteLine("Submarine is sunken");
                            foreach (string item in EnLocation.Ships[3].Cover)
                            {
                                int a = Transformacja2(item[0]);
                                int b = Transformacja3(item[1]);
                                EnOcean.Board[a,b].SetFront(Square.Mark.SUNK);
                            }
                        }
                        System.Threading.Thread.Sleep(2000);
                        myHits++;
                    }
                    else if (EnOcean.Board[x,y].GetFront()== Square.Mark.DESTROYER)
                    {
                        Console.WriteLine("You hit Destroyer");
                        EnLocation.Ships[4].Width--;
                        if (EnLocation.Ships[4].Width==0) 
                        {
                            Console.WriteLine("Destroyer is sunken");
                            foreach (string item in EnLocation.Ships[4].Cover)
                            {
                                int a = Transformacja2(item[0]);
                                int b = Transformacja3(item[1]);
                                EnOcean.Board[a,b].SetFront(Square.Mark.SUNK);
                            }
                        }

                        System.Threading.Thread.Sleep(2000);
                        myHits++;
                    }
                    else
                    {
                        Console.WriteLine("You missed");
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("You hit there before!!! Be carreful.");
                    System.Threading.Thread.Sleep(1500);
                }
                if (myHits == 15) {break;}
                // enemy turn

                // enemy turn

                Console.Clear();
                Console.WriteLine("         Player vs. AI battleship game");
                Console.WriteLine();
                DisplayTwoBoards(EnOcean.Board, MyOcean.Board);
                Console.WriteLine();
            }
            // winner anouncement
            Console.Clear();
            Console.WriteLine("         Player vs. AI battleship game");
            Console.WriteLine();
            DisplayTwoBoards(EnOcean.Board, MyOcean.Board);
            Console.WriteLine();
            
            if (myHits == 15)
            {
                Console.WriteLine("Congratulation. You are the WINER !!!");
            }
            else if (enemyHits == 15)
            {
                Console.WriteLine("Sorry. AI is the WINER !!!");
            }
            else
            {
                Console.WriteLine("Draw state");
            }
            Console.WriteLine("The game is over. See you next time");
            // end of game
            

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
                    else if (e == "SUNK")
                    {
                        line1 += "# ";
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
                Console.Write(" |" + line1 + "|   ");// + "|     |" + line2 + "| ");
                Console.Write("{0}", (char)(65+i));
                Console.WriteLine(" |" + line2 + "|");
                line1 = "";
                line2 = "";
            }
            Console.WriteLine("  |--------------------|     |--------------------|");
        }

        public void AutoPlacement(ShipsLocation lok)
        {
            Random random = new Random();
            int size = 5;
            List<int> intlist = new List<int>();
            List<string> strlist = new List<string>();
                        
            for (int index = 0; index < 5; index++) // po wszystkich statkach
            {
                bool not_find = true;
                while (not_find)
                {
                    int orient = random.Next(2);
                    int x = random.Next(10);
                    int y = random.Next(10);
                    if (orient == 0)  //horizontal
                    {
                        if ( y < 11-size)
                        {
                            int ileh = 0;
                            for (int s = y; s< y+size; s++)
                            {
                                if (!lok.Plansza[x,s])
                                {
                                    ileh++;
                                    intlist.Add(x);
                                    intlist.Add(s); 
                                }
                            }
                            if (ileh == size)
                            {
                                strlist = Transformacja(intlist);
                                lok.Ships[index].Cover = Transformacja1(strlist);
                                string fn = strlist[0];
                                int a = (int)fn[0] - 48;
                                int b = (int)fn[1] - 48;
                                for (int i = a-1; i < a+2; i++)
                                {
                                    for (int j = b-1; j< b+size+1; j++)
                                    {
                                        if ((i>=0 && i<=9) && (j>=0 && j <=9))
                                        {
                                            lok.Plansza[i,j] = true;
                                        }
                                    }
                                }
                                not_find = false;
                                intlist.Clear();
                                strlist.Clear();
                            }
                            else
                            {
                                ileh = 0;
                                intlist.Clear();
                            }
                        }
                    }
                    else if (orient == 1)  // vertical
                    {
                        if ( x < 11-size)
                        {
                            int ilev = 0;
                            for (int s = x; s< x+size; s++)
                            {
                                if (!lok.Plansza[s,y])
                                {
                                    ilev++;
                                    intlist.Add(s);
                                    intlist.Add(y); 
                                }
                            }
                            if (ilev == size)
                            {
                                strlist = Transformacja(intlist);
                                lok.Ships[index].Cover = Transformacja1(strlist);
                                string fn = strlist[0];
                                int a = (int)fn[0] - 48;
                                int b = (int)fn[1] - 48;
                                for (int i = a-1; i < a+size+1; i++)
                                {
                                    for (int j = b-1; j< b+2; j++)
                                    {
                                        if ((i>=0 && i<=9) && (j>=0 && j <=9))
                                        {
                                            lok.Plansza[i,j] = true;
                                        }
                                    }
                                }
                                not_find = false;
                                intlist.Clear();
                                strlist.Clear();
                            }
                            else
                            {
                                ilev = 0;
                                intlist.Clear();
                            }
                        }
                    }
                }
                size --;
                //stop++;
            }
        }
        
        List<string> Transformacja(List<int> lista)
        {
            List<string> strlista = new List<string>();
            string together = "";
            int counter = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                counter++;
                together += lista[i].ToString();
                if (counter == 2)
                {
                    strlista.Add(together);
                    counter = 0;
                    together = "";
                }
            }
            return strlista;
        }
        
        List<string> Transformacja1(List<string> lista)
        {
            char first;
            char[] initial = new char[2];
            List<string> a1lista = new List<string>();
            foreach (string item in lista)
            {
                first = item[0];
                
                if (first == '0') first = 'A';
                if (first == '1') first = 'B';
                if (first == '2') first = 'C';
                if (first == '3') first = 'D';
                if (first == '4') first = 'E';
                if (first == '5') first = 'F';
                if (first == '6') first = 'G';
                if (first == '7') first = 'H';
                if (first == '8') first = 'I';
                if (first == '9') first = 'J';
                initial[0] = first;
                initial[1] = item[1];
                string s = new string(initial);
                a1lista.Add(s);
            }
            return a1lista;
        }

        int Transformacja2(char ch)
        {
            if (ch == 'A'){return 0;}
            else if (ch == 'B') {return 1;}
            else if (ch == 'C') {return 2;}
            else if (ch == 'D') {return 3;}
            else if (ch == 'E') {return 4;}
            else if (ch == 'F') {return 5;}
            else if (ch == 'G') {return 6;}
            else if (ch == 'H') {return 7;}
            else if (ch == 'I') {return 8;}
            else {return 9;}
        }
        int Transformacja3(char ch)
        {
            if (ch == '0'){return 0;}
            else if (ch == '1') {return 1;}
            else if (ch == '2') {return 2;}
            else if (ch == '3') {return 3;}
            else if (ch == '4') {return 4;}
            else if (ch == '5') {return 5;}
            else if (ch == '6') {return 6;}
            else if (ch == '7') {return 7;}
            else if (ch == '8') {return 8;}
            else {return 9;}
        }
        public void PlaceShipM(ShipsLocation loka, Ocean ocea)
        {
            int counter = 0;
            foreach (Ship item in loka.Ships)
            {
                //read in loop Cover list element
                string temp = "";
                for (int i = 0; i < item.Cover.Count; i++)
                {
                    temp = item.Cover[i];
                    int x = (int)(temp[0])-65;
                    int y = (int)(temp[1])-48;
                    ocea.Board[x,y].SetFront((Square.Mark)counter);
                }
                counter++;
            }
        }

        public void PlaceShipE(ShipsLocation loka, Ocean ocea)
        {
            int counter = 0;
            foreach (Ship item in loka.Ships)
            {
                //read in loop Cover list element
                string temp = "";
                for (int i = 0; i < item.Cover.Count; i++)
                {
                    temp = item.Cover[i];
                    int x = (int)(temp[0])-65;
                    int y = (int)(temp[1])-48;
                    ocea.Board[x,y].SetBack((Square.Mark)counter);
                }
                counter++;
            }
        }
    }
}