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
            
            int myHits = 0;  //zlicza sumaryczną ilość hits - do zakończenia rozgrywki
            int enemyHits = 0;  //zlicza sumaryczną ilość hits - do zakończenia rozgrywki
            bool nextTurn = true; // argument while
            
            bool hCarrier = false;  // warunek częściowego uszkodzenia
            bool hBattleship= false;
            bool hCruiser = false;
            bool hSubmarine = false;
                       
            List<int> carhits = new List<int>();  //lista coords, do strategii AI
            List<int> bathits = new List<int>();
            List<int> cruhits = new List<int>();
            List<int> subhits = new List<int>();
            List<int> deshits = new List<int>();
            int ex = 0; // x-coord enemy
            int ey = 0; // y-cord emnemy
            
            // PETLA WHILE WHILE WHILE
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
                
                //********************************************************
                // enemy turn
                if (hCarrier)
                {
                    if (MyOcean.Board[ex,ey].GetFront()== Square.Mark.HIT) //jeżeli jest trafiony
                    {
                        carhits.Add(ex);
                        carhits.Add(ey);
                        if (carhits.Count == 2)  //jedno trafienie
                        {
                            if (ex+1 < 10 && !MyLocation.Plansza[ex+1,ey]) 
                            {
                                ex = ex+1;
                                MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                            }
                            else
                            {
                                if (ey+1<10 && !MyLocation.Plansza[ex,ey+1]) 
                                {
                                    ey = ey+1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else
                                {
                                    if (ex-1>=0 && !MyLocation.Plansza[ex-1,ey]) 
                                    {
                                        ex = ex-1;
                                        MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                    }
                                    else if (ey-1>=0 && !MyLocation.Plansza[ex,ey-1]) 
                                    {
                                        ey = ey-1;
                                        MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                    }
                                }
                            }
                            
                        }
                        else if (carhits.Count > 2)
                        {
                            // mozna zacząć wnioskować, mamy dwa hity w carhits
                            if (carhits[0] != carhits[2]) //vertical
                            {
                                if (carhits[0]+1 <10 && !MyLocation.Plansza[carhits[0]+1,carhits[1]])
                                {
                                    ex = carhits[0]+1;
                                    ey = carhits[1];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[0]-1 >=0 && !MyLocation.Plansza[carhits[0]-1,carhits[1]])
                                {
                                    ex = carhits[0]- 1;
                                    ey = carhits[1];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[2]+1 <10 && !MyLocation.Plansza[carhits[2]+1,carhits[3]])
                                {
                                    ex = carhits[2]+1;
                                    ey = carhits[3];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[2]-1 >=0 && !MyLocation.Plansza[carhits[2]-1,carhits[3]])
                                {
                                    ex = carhits[2]- 1;
                                    ey = carhits[3];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[4]+1 <10 && !MyLocation.Plansza[carhits[4]+1,carhits[5]])
                                {
                                    ex = carhits[4]+1;
                                    ey = carhits[5];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[4]-1 >=0 && !MyLocation.Plansza[carhits[4]-1,carhits[5]])
                                {
                                    ex = carhits[4]- 1;
                                    ey = carhits[5];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[6]+1 <10 && !MyLocation.Plansza[carhits[6]+1,carhits[7]])
                                {
                                    ex = carhits[6]+1;
                                    ey = carhits[7];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[6]- 1 >=0 && MyLocation.Plansza[carhits[6]- 1,carhits[7]])
                                {
                                    ex = carhits[6]- 1;
                                    ey = carhits[7];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }

                            }
                            else  //horizontal
                            {
                                if (carhits[1]+1 <10 && !MyLocation.Plansza[carhits[0],carhits[1]+1])
                                {
                                    ex = carhits[0];
                                    ey = carhits[1]+1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[1]-1 >=0 && !MyLocation.Plansza[carhits[0],carhits[1]-1])
                                {
                                    ex = carhits[0];
                                    ey = carhits[1]-1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[3]+1 <10 && !MyLocation.Plansza[carhits[2],carhits[3]+1])
                                {
                                    ex = carhits[2];
                                    ey = carhits[3]+1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[3]-1 >=0 && !MyLocation.Plansza[carhits[2],carhits[3]-1])
                                {
                                    ex = carhits[2];
                                    ey = carhits[3]-1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[5]+1 <10 && !MyLocation.Plansza[carhits[4],carhits[5]+1])
                                {
                                    ex = carhits[4];
                                    ey = carhits[5]+1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[5]-1 >=0 && !MyLocation.Plansza[carhits[4],carhits[5]-1])
                                {
                                    ex = carhits[4];
                                    ey = carhits[5]-1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[7]+1 <10 && !MyLocation.Plansza[carhits[6],carhits[7]+1])
                                {
                                    ex = carhits[6];
                                    ey = carhits[7]+1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[7]-1>=0 && MyLocation.Plansza[carhits[6],carhits[7]-1])
                                {
                                    ex = carhits[6];
                                    ey = carhits[7]-1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                            }
                            
                        }
                    }
                    else
                    {
                        // zainteresowany cruiserem ale pudło, mozna zacząć wnioskować jeden hit w cruhits i pudło
                        if (carhits[0]+1 < 10 && !MyLocation.Plansza[carhits[0]+1,carhits[1]]) 
                        {
                            ex = carhits[0]+1;
                            ey = carhits[1];
                            MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                        }
                        else
                        {
                            if (carhits[1]+1<10 && !MyLocation.Plansza[carhits[0],carhits[1]+1]) 
                            {
                                ex = carhits[0];
                                ey = carhits[1]+1;
                                MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                            }
                            else
                            {
                                if (carhits[0]-1>=0 && !MyLocation.Plansza[carhits[0]-1,carhits[1]]) 
                                {
                                    ex = carhits[0]-1;
                                    ey = carhits[1];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (carhits[1]-1>=0 && !MyLocation.Plansza[carhits[0], carhits[1]-1])
                                {
                                    ex = carhits[0];
                                    ey = carhits[1]-1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                            }
                        }
                        
                    }
                }
                else if (hBattleship)
                {
                    if (MyOcean.Board[ex,ey].GetFront()== Square.Mark.HIT) //jeżeli jest trafiony
                    {
                        bathits.Add(ex);
                        bathits.Add(ey);
                        if (bathits.Count == 2)  //jedno trafienie
                        {
                            if (ex+1 < 10 && !MyLocation.Plansza[ex+1,ey]) 
                            {
                                ex = ex+1;
                                MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                            }
                            else
                            {
                                if (ey+1<10 && !MyLocation.Plansza[ex,ey+1]) 
                                {
                                    ey = ey+1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else
                                {
                                    if (ex-1>=0 && !MyLocation.Plansza[ex-1,ey]) 
                                    {
                                        ex = ex-1;
                                        MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                    }
                                    else if (ey-1 >=0 && !MyLocation.Plansza[ex,ey-1])
                                    {
                                        ey = ey-1;
                                        MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                    }
                                }
                            }
                            
                        }
                        else if (bathits.Count > 2)
                        {
                            // mozna zacząć wnioskować, mamy dwa hity w bathits
                            if (bathits[0] != bathits[2]) //vertical
                            {
                                if (bathits[0]+1 < 10 && !MyLocation.Plansza[bathits[0]+1,bathits[1]])
                                {
                                    ex = bathits[0]+1;
                                    ey = bathits[1];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (bathits[0]-1 >=0 && !MyLocation.Plansza[bathits[0]-1,bathits[1]])
                                {
                                    ex = bathits[0]- 1;
                                    ey = bathits[1];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (bathits[2]+1 <10 && !MyLocation.Plansza[bathits[2]+1,bathits[3]])
                                {
                                    ex = bathits[2]+1;
                                    ey = bathits[3];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (bathits[2]-1 >=0 && !MyLocation.Plansza[bathits[2]-1,bathits[3]])
                                {
                                    ex = bathits[2]- 1;
                                    ey = bathits[3];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                 else if (bathits[4]+1 <10 && !MyLocation.Plansza[bathits[4]+1,bathits[5]])
                                {
                                    ex = bathits[4]+1;
                                    ey = bathits[5];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (bathits[4]- 1>=0 && !MyLocation.Plansza[bathits[4]- 1,bathits[5]])
                                {
                                    ex = bathits[4]- 1;
                                    ey = bathits[5];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }

                            }
                            else  //horizontal
                            {
                                if (bathits[1]+1 <10 && !MyLocation.Plansza[bathits[0],bathits[1]+1])
                                {
                                    ex = bathits[0];
                                    ey = bathits[1]+1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (bathits[1]-1 >= 0 && !MyLocation.Plansza[bathits[0],bathits[1]-1])
                                {
                                    ex = bathits[0];
                                    ey = bathits[1]-1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (bathits[3]+1<10 && !MyLocation.Plansza[bathits[2],bathits[3]+1])
                                {
                                    ex = bathits[2];
                                    ey = bathits[3]+1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (bathits[3]-1 >=0 && !MyLocation.Plansza[bathits[2],bathits[3]-1])
                                {
                                    ex = bathits[2];
                                    ey = bathits[3]-1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (bathits[5]+1 <10 && !MyLocation.Plansza[bathits[4],bathits[5]+1])
                                {
                                    ex = bathits[4];
                                    ey = bathits[5]+1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (bathits[5]-1 >=0 && MyLocation.Plansza[bathits[4],bathits[5]-1])
                                {
                                    ex = bathits[4];
                                    ey = bathits[5]-1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                            }
                            
                        }
                    }
                    else
                    {
                        // zainteresowany cruiserem ale pudło, mozna zacząć wnioskować jeden hit w cruhits i pudło
                        if (bathits[0]+1 < 10 && !MyLocation.Plansza[bathits[0]+1,bathits[1]]) 
                        {
                            ex = bathits[0]+1;
                            ey = bathits[1];
                            MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                        }
                        else
                        {
                            if (bathits[1]+1<10 && !MyLocation.Plansza[bathits[0],bathits[1]+1]) 
                            {
                                ex = bathits[0];
                                ey = bathits[1]+1;
                                MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                            }
                            else
                            {
                                if (bathits[0]-1>=0 && !MyLocation.Plansza[bathits[0]-1,bathits[1]]) 
                                {
                                    ex = bathits[0]-1;
                                    ey = bathits[1];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (bathits[1]-1>=0 && !MyLocation.Plansza[bathits[0],bathits[1]-1])
                                {
                                    ex = bathits[0];
                                    ey = bathits[1]-1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                            }
                        }
                        
                    }
                }
                else if (hCruiser)
                {
                    if (MyOcean.Board[ex,ey].GetFront()== Square.Mark.HIT) //jeżeli jest trafiony
                    {
                        cruhits.Add(ex);
                        cruhits.Add(ey);
                        if (cruhits.Count == 2)  //jedno trafienie
                        {
                            if (ex+1 < 10 && !MyLocation.Plansza[ex+1,ey]) 
                            {
                                ex = ex+1;
                                MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                            }
                            else
                            {
                                if (ey+1<10 && !MyLocation.Plansza[ex,ey+1]) 
                                {
                                    ey = ey+1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else
                                {
                                    if (ex-1>=0 && !MyLocation.Plansza[ex-1,ey]) 
                                    {
                                        ex = ex-1;
                                        MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                    }
                                    else if (ey-1 >=0 && !MyLocation.Plansza[ex,ey-1])
                                    {
                                        ey = ey-1;
                                        MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                    }
                                }
                            }
                            
                        }
                        else if (cruhits.Count > 2)
                        {
                            // mozna zacząć wnioskować, mamy dwa hity w cruhits
                            if (cruhits[0] != cruhits[2]) //vertical
                            {
                                if (cruhits[0]+1 <10 && !MyLocation.Plansza[cruhits[0]+1,cruhits[1]])
                                {
                                    ex = cruhits[0]+1;
                                    ey = cruhits[1];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (cruhits[0]-1 >=0 && !MyLocation.Plansza[cruhits[0]-1,cruhits[1]])
                                {
                                    ex = cruhits[0]- 1;
                                    ey = cruhits[1];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (cruhits[2]+1 <10 && !MyLocation.Plansza[cruhits[2]+1,cruhits[3]])
                                {
                                    ex = cruhits[2]+1;
                                    ey = cruhits[3];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (cruhits[2]- 1 >=0 && MyLocation.Plansza[cruhits[2]- 1,cruhits[3]])
                                {
                                    ex = cruhits[2]- 1;
                                    ey = cruhits[3];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }

                            }
                            else  //horizontal
                            {
                                if (cruhits[1]+1 <10 && !MyLocation.Plansza[cruhits[0],cruhits[1]+1])
                                {
                                    ex = cruhits[0];
                                    ey = cruhits[1]+1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (cruhits[1]-1 >=0 && !MyLocation.Plansza[cruhits[0],cruhits[1]-1])
                                {
                                    ex = cruhits[0];
                                    ey = cruhits[1]-1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (cruhits[3]+1 <10 && !MyLocation.Plansza[cruhits[2],cruhits[3]+1])
                                {
                                    ex = cruhits[2];
                                    ey = cruhits[3]+1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (cruhits[3]-1 >=0 && !MyLocation.Plansza[cruhits[2],cruhits[3]-1])
                                {
                                    ex = cruhits[2];
                                    ey = cruhits[3]-1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                            }
                            
                        }
                    }
                    else
                    {
                        // zainteresowany cruiserem ale pudło, mozna zacząć wnioskować jeden hit w cruhits i pudło
                        if (cruhits[0]+1 < 10 && !MyLocation.Plansza[cruhits[0]+1,cruhits[1]]) 
                        {
                            ex = cruhits[0]+1;
                            ey = cruhits[1];
                            MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                        }
                        else
                        {
                            if (cruhits[1]+1<10 && !MyLocation.Plansza[cruhits[0],cruhits[1]+1]) 
                            {
                                ex = cruhits[0];
                                ey = cruhits[1]+1;
                                MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                            }
                            else
                            {
                                if (cruhits[0]-1>=0 && !MyLocation.Plansza[cruhits[0]-1,cruhits[1]]) 
                                {
                                    ex = cruhits[0]-1;
                                    ey = cruhits[1];
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                                else if (cruhits[1]-1>=0 && !MyLocation.Plansza[cruhits[0],cruhits[1]-1])
                                {
                                    ex = cruhits[0];
                                    ey = cruhits[1]-1;
                                    MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                                }
                            }
                        }
                        
                    }
                }
                else if (hSubmarine)
                {
                    subhits.Add(ex);
                    subhits.Add(ey);
                    if (MyOcean.Board[ex,ey].GetFront()== Square.Mark.HIT) //jeżeli jest trafiony
                    {
                        if (ex+1 < 10 && !MyLocation.Plansza[ex+1,ey]) {ex = ex+1;}
                        else
                        {
                            if (ey+1<10 && !MyLocation.Plansza[ex,ey+1]) {ey = ey+1;}
                            else
                            {
                                if (ex-1>=0 && !MyLocation.Plansza[ex-1,ey]) {ex = ex-1;}
                                else {ey = ey-1;}
                            }
                        }
                        MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                    }
                    else
                    {
                        // zainteresowany submarine ale pudło, mozna zacząć wnioskować jeden hit w subhits i pudło
                        if (subhits[0]+1 < 10 && !MyLocation.Plansza[subhits[0]+1,subhits[1]]) 
                        {
                            ex = subhits[0]+1;
                            ey = subhits[1];
                        }
                        else
                        {
                            if (subhits[1]+1<10 && !MyLocation.Plansza[subhits[0],subhits[1]+1]) 
                            {
                                ex = subhits[0];
                                ey = subhits[1]+1;
                            }
                            else
                            {
                                if (subhits[0]-1>=0 && !MyLocation.Plansza[subhits[0]-1,subhits[1]]) 
                                {
                                    ex = subhits[0]-1;
                                    ey = subhits[1];
                                }
                                else 
                                {
                                    ex = subhits[0];
                                    ey = subhits[1]-1;
                                }
                            }
                        }
                        MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                    }
                }
                else   // nie ma częściowego trafienia
                { 
                    
                    Console.WriteLine("Testing tool to avoid random hit");
                    string sex = Console.ReadLine();
                    ex = Int32.Parse(sex);
                    string sey = Console.ReadLine();
                    ey = Int32.Parse(sey);
                    /*
                    if (enemyHits<16)
                    {
                        ex = random.Next(10); //losowanie koordynat
                        ey = random.Next(10);
                        while (MyLocation.Plansza[ex,ey])  //losuje aż znajdzie wolne
                        {
                            ex = random.Next(10);
                            ey = random.Next(10);
                        }
                        MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square
                    }
                    else
                    {
                       
                    }*/
                }
                                
                MyOcean.Board[ex,ey].upsideDown();  //przewrotka na myOcean respective Square
                MyLocation.Plansza[ex,ey] = true;   // zablokowanie tego Square

                if (MyOcean.Board[ex,ey].GetBack()== Square.Mark.CARRIER)
                {
                    hCarrier = true;
                    MyLocation.Ships[0].Width--;
                    enemyHits++;
                    if (MyLocation.Ships[0].Width==0)
                    {
                        foreach (string item in MyLocation.Ships[0].Cover)
                        {
                            int a = Transformacja2(item[0]);
                            int b = Transformacja3(item[1]);
                            MyOcean.Board[a,b].SetFront(Square.Mark.SUNK);
                            hCarrier = false;
                        
                            if ((a>0 && a<9) && (b>0 && b<9))
                            {
                                MyLocation.Plansza[a+1,b-1] = true;
                                MyLocation.Plansza[a+1,b] = true;
                                MyLocation.Plansza[a+1,b+1] = true;
                                MyLocation.Plansza[a,b-1] = true;
                                MyLocation.Plansza[a,b+1] = true;
                                MyLocation.Plansza[a-1,b-1] = true;
                                MyLocation.Plansza[a-1,b] = true;
                                MyLocation.Plansza[a-1,b+1] = true;
                            }
                        }
                    }
                }
                else if (MyOcean.Board[ex,ey].GetBack()== Square.Mark.BATTLESHIP)
                {
                    hBattleship = true;
                    MyLocation.Ships[1].Width--;
                    enemyHits++;
                    if (MyLocation.Ships[1].Width==0)
                    {
                        foreach (string item in MyLocation.Ships[1].Cover)
                        {
                            int a = Transformacja2(item[0]);
                            int b = Transformacja3(item[1]);
                            MyOcean.Board[a,b].SetFront(Square.Mark.SUNK);
                            hBattleship = false;
                        
                            if ((a>0 && a<9) && (b>0 && b<9))
                            {
                                MyLocation.Plansza[a+1,b-1] = true;
                                MyLocation.Plansza[a+1,b] = true;
                                MyLocation.Plansza[a+1,b+1] = true;
                                MyLocation.Plansza[a,b-1] = true;
                                MyLocation.Plansza[a,b+1] = true;
                                MyLocation.Plansza[a-1,b-1] = true;
                                MyLocation.Plansza[a-1,b] = true;
                                MyLocation.Plansza[a-1,b+1] = true;
                            }
                               
                        }
                            
                    }
                }
                else if (MyOcean.Board[ex,ey].GetBack()== Square.Mark.CRUISER)
                {
                    hCruiser = true;
                    MyLocation.Ships[2].Width--;
                    enemyHits++;
                    if (MyLocation.Ships[2].Width==0)
                    {
                        foreach (string item in MyLocation.Ships[2].Cover)
                        {
                            int a = Transformacja2(item[0]);
                            int b = Transformacja3(item[1]);
                            MyOcean.Board[a,b].SetFront(Square.Mark.SUNK);
                            hCruiser = false;
                        
                            if ((a>0 && a<9) && (b>0 && b<9))
                            {
                                MyLocation.Plansza[a+1,b-1] = true;
                                MyLocation.Plansza[a+1,b] = true;
                                MyLocation.Plansza[a+1,b+1] = true;
                                MyLocation.Plansza[a,b-1] = true;
                                MyLocation.Plansza[a,b+1] = true;
                                MyLocation.Plansza[a-1,b-1] = true;
                                MyLocation.Plansza[a-1,b] = true;
                                MyLocation.Plansza[a-1,b+1] = true;
                            }
                                
                        }
                            
                    }

                }
                else if (MyOcean.Board[ex,ey].GetBack()== Square.Mark.SUBMARINE)
                {
                    hSubmarine = true;
                    MyLocation.Ships[3].Width--;
                    enemyHits++;
                    if (MyLocation.Ships[3].Width==0)
                    {
                        foreach (string item in MyLocation.Ships[3].Cover)
                        {
                            int a = Transformacja2(item[0]);
                            int b = Transformacja3(item[1]);
                            MyOcean.Board[a,b].SetFront(Square.Mark.SUNK);
                            hSubmarine = false;

                            if ((a>0 && a<9) && (b>0 && b<9))
                            {
                                MyLocation.Plansza[a+1,b-1] = true;
                                MyLocation.Plansza[a+1,b] = true;
                                MyLocation.Plansza[a+1,b+1] = true;
                                MyLocation.Plansza[a,b-1] = true;
                                MyLocation.Plansza[a,b+1] = true;
                                MyLocation.Plansza[a-1,b-1] = true;
                                MyLocation.Plansza[a-1,b] = true;
                                MyLocation.Plansza[a-1,b+1] = true;
                            }
                                
                        }
                          
                    }
                }
                else if (MyOcean.Board[ex,ey].GetBack()== Square.Mark.DESTROYER)
                {
                    MyLocation.Ships[4].Width--;
                    enemyHits++;
                    if (MyLocation.Ships[4].Width==0)
                    {
                        foreach (string item in MyLocation.Ships[4].Cover)
                        {
                            int a = Transformacja2(item[0]);
                            int b = Transformacja3(item[1]);
                            MyOcean.Board[a,b].SetFront(Square.Mark.SUNK);
                                                
                            if ((a>0 && a<9) && (b>0 && b<9))
                            {
                                MyLocation.Plansza[a+1,b-1] = true;
                                MyLocation.Plansza[a+1,b] = true;
                                MyLocation.Plansza[a+1,b+1] = true;
                                MyLocation.Plansza[a,b-1] = true;
                                MyLocation.Plansza[a,b+1] = true;
                                MyLocation.Plansza[a-1,b-1] = true;
                                MyLocation.Plansza[a-1,b] = true;
                                MyLocation.Plansza[a-1,b+1] = true;
                            }
                               
                        }
                    }
                }
                if (enemyHits==15) {break;}

                //sprawdzenie MyLocation.Plansza  SSSSSSSSSSSSSSSSSSS
                for (int i = 0; i<10; i++)
                {
                    for (int j=0; j<10;j++)
                    {
                        Console.Write(MyLocation.Plansza[i,j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
                // SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS

                Console.Clear();
                Console.WriteLine("         Player vs. AI battleship game");
                Console.WriteLine();
                DisplayTwoBoards(EnOcean.Board, MyOcean.Board);
                Console.WriteLine();
            
            }  // konniec WHILE WHILE WHILE
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
            
            // end of game
            Console.WriteLine("The game is over. See you next time");

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
                        line1 += "? ";
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
                        line2 += "# ";
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
                    ocea.Board[x,y].SetBack((Square.Mark.HIT));
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