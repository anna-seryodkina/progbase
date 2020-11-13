using static System.Console;
using static System.Math;


class lab3_part2_
{
    static void Main()
    {
        
        int [,] zeroOneArray = new int [,]
        {
            {0, 0, 0, 1, 0, 1, 1, 0},
            {0, 0, 1, 1, 0, 1, 1, 0},
            {0, 0, 1, 1, 0, 1, 0, 0},
            {0, 1, 1, 0, 0, 0, 0, 0},
            {0, 1, 0, 1, 1, 0, 0, 1},
            {1, 1, 0, 1, 0, 1, 1, 0},
            {0, 0, 1, 1, 1, 1, 1, 0},
            {1, 0, 0, 0, 0, 0, 1, 1},
            {0, 1, 0, 0, 1, 1, 0, 0},
            {1, 1, 0, 1, 1, 1, 0, 0},
            {1, 1, 1, 1, 1, 1, 1, 1},
        };

        // 0 - water; 1 - land;

        int [,] newLandArray = new int [zeroOneArray.GetLength(0), zeroOneArray.GetLength(1)];

        int c;
        c = 1;
        
        for (int i = 0; i < newLandArray.GetLength(0); i++)
        {
            for (int j = 0; j < newLandArray.GetLength(1); j++)
            {
                
                if (zeroOneArray[i,j] == 0)
                {
                    newLandArray [i,j] = 0;
                } else {
                    newLandArray [i,j] = c;
                    c ++;
                }
            }
        }


        int [] counters = new int[c]; 

        for (int i = 0; i < c; i++)
        {
            if (i == 0)
            {
                counters [i] = 0;
            } else {
                counters [i] = 1;
            }
        }


        int changes = 0;
        changes = checkNewLand (newLandArray, counters, changes); 

        while (changes > 0)
        {
            changes = checkNewLand (newLandArray, counters, changes);
        }

        int nIslands = 0;
        int cMax =0;

        for (int i = 0; i < c; i++)
        {
            int size = counters [i];

            if (size > 0)
            {
                nIslands ++;
            }

            if(size > cMax)
            {
                cMax = size;
            }
        }


        WriteLine ( "> number of islands: {0}", nIslands );
        WriteLine ();


        WaterToLandSpot(newLandArray, counters, cMax);
        WriteLine ();


        WriteLine ("> Your map:");
        PrintMatrix (newLandArray);





        // -------------- Functions: --------------

        static int checkNewLand (int [,] landArr, int [] count, int nChanges)
        {
            
            nChanges = 0;

            for (int i = 0; i < landArr.GetLength(0); i++)
            {
                for (int j = 0; j < landArr.GetLength(1); j++)
                {
                    
                    if (landArr[i,j] == 0)
                    {
                        continue;
                    }

                    
                    int prevValue = landArr [i,j];


                    if (i+1 < landArr.GetLength(0) && landArr[i+1,j] > 0 && landArr[i+1,j] < landArr[i,j])
                    {
                        landArr[i,j] = landArr[i+1,j];
                    }

                    if (i-1 >= 0 && landArr[i-1,j] > 0 && landArr[i-1,j] < landArr[i,j])
                    {
                        landArr[i,j] = landArr[i-1,j];
                    }

                    if (j+1 < landArr.GetLength(1) && landArr[i,j+1] > 0 && landArr[i,j+1] < landArr[i,j])
                    {
                        landArr[i,j] = landArr[i,j+1];
                    }

                    if (j-1 >= 0 && landArr[i,j-1] > 0 && landArr[i,j-1] < landArr[i,j])
                    {
                        landArr[i,j] = landArr[i,j-1];
                    }


                    if (prevValue != landArr[i,j])
                    {
                        nChanges ++;
                        count [prevValue] = count[prevValue] - 1;
                        count [landArr[i,j]] ++;
                    }
                    
                    
                }
            }

            return nChanges;
        }


        
        static void WaterToLandSpot (int [,] landArr, int [] count, int cMax)
        {
            int waterI=0;
            int waterJ=0;

            int size1=0;
            int size2=0;
            int newSize=0;
            int sizeWithWater=0;
            

            for (int i = 0; i < landArr.GetLength(0); i++)
            {
                for (int j = 0; j < landArr.GetLength(1); j++)
                {
                    if (landArr[i,j] != 0)
                    {
                        continue;
                    }

                    if (i+1 < landArr.GetLength(0) && i-1 >= 0 && j+1 < landArr.GetLength(1) && j-1 >= 0)
                    {
                        int down  = landArr [i+1,j];
                        int up    = landArr [i-1,j];
                        int right = landArr [i,j+1];
                        int left  = landArr [i,j-1];
                        
                    
                        if (down != 0 || up != 0 || right != 0 || left != 0)
                        {
                            if (up==0 && right==0 && left==0)
                            {
                                size1 = count [down];
                            }
                            
                            
                            if (down==0 && right==0 && left==0)
                            {
                                size1 = count [up];
                            }

                            if (down==0 && up==0 && left==0)
                            {
                                size1 = count [right];
                            }

                            if (down==0 && up==0 && right==0)
                            {
                                size1 = count [left];
                            }

                            newSize = size1 + 1;
                        }


                        if (down != up && down > 0 && up > 0)
                        {
                            size1 = count [ down ];
                            size2 = count [ up ];                            
                        } 

                        if (right != left && right > 0 && left > 0) 
                        {
                            size1 = count [ right ];
                            size2 = count [ left ];
                        }

                        newSize = size1 + size2 + 1;

                        if (newSize > cMax)
                        {
                            waterI = i;
                            waterJ = j;
                            sizeWithWater = newSize;
                        }
                
                    }
                     
                }
            }

            WriteLine ($"> If you add land here: i = {waterI}, j = {waterJ}, you will create the biggest island with size: {sizeWithWater}");
        }
        

        static void PrintMatrix (int [,] landArr)
        {
            int width = landArr.GetLength(1) + 2;
            RectWidth (width);
            WriteLine ();

            for (int i = 0; i < landArr.GetLength(0); i ++) 
            {
                Write ("| ");
                for (int j = 0; j < landArr.GetLength(1); j ++)
                {
                    int value = landArr [i,j];
                    if (value == 0){
                        BackgroundColor = System.ConsoleColor.DarkCyan;
                        Write ("  ");
                    } else {
                        BackgroundColor = System.ConsoleColor.DarkYellow;
                        Write ("  ");
                    }
                    ResetColor();
                }
                Write (" |");
                WriteLine ();
            }
            ResetColor();

            RectWidth (width);
            WriteLine();
        }


        static void RectWidth (int width)
        {
            for (int i = 0; i <= width; i ++ )
            {
                if (i == 0 || i == width) {
                    Write ("+");
                } else {
                    Write ("--");
                }
            }
        }

    }
}