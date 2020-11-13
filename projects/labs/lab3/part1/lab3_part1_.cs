using static System.Console;
using static System.Math;


class lab3_part1_
{
    static void Main(){

        int arrayLength;
        
        WriteLine ( "Enter number of heights:" );
        arrayLength = int.Parse ( ReadLine() );

        if (arrayLength < 1){
            WriteLine ( "is not correct" );
        } else {
            int [] firstArray = new int [arrayLength]; 

            WriteLine ( "Enter heights:" );

            for (int i =0; i < arrayLength; i++)
            {
                firstArray [i] = int.Parse ( ReadLine () );
            }
            
            
            int [] normArray = new int [arrayLength];

            int minV = Abs ( FindMin(firstArray) );
            
            for (int i = 0; i < arrayLength; i++)
            {
                normArray [i] = firstArray[i] + minV;
            }




            double [] thirdArray = new double [arrayLength]; // < ---- "max is 1" array

            int maxV = FindMax (normArray);

            for (int item = 0; item < arrayLength; item ++)
            {
                thirdArray [item] = (double) normArray[item] / maxV;
                thirdArray [item] = Round (thirdArray[item], 3);
            }
            
            
            int waterLvl;

            WriteLine ( "Enter water level:" );
            waterLvl = int.Parse ( ReadLine () );

            if (waterLvl < 0 || waterLvl > maxV){
                WriteLine ( "is not correct" );
            } else {

                int [] waterArray = new int [arrayLength];
                FillWaterArr (normArray, arrayLength, waterArray, waterLvl);
                

                int [,] forOutput = new int [maxV, arrayLength];
                FillForOutputArr (normArray, forOutput, waterLvl);


                
                WriteLine ("");
                WriteLine ( "> Your map:" );

                int width = arrayLength + 2;
                int height = maxV + 2; 

                Print_Rect_and_Matrix (width, height, forOutput);

                
                int CursorStartPosition = CursorTop;
                PrintHeights (CursorStartPosition, maxV, width, waterLvl);
                


                int area = Mountain (normArray, maxV, waterLvl);
                int fullArea = 1 * area;

                WriteLine ();
                WriteLine ( "> Area of the highest mountain: {0} sq. m.", fullArea );
                WriteLine ();
            }
        }


        
        // --------------- Functions: ---------------
        


        static int FindMin (int[] firstArray) 
        {
            int min = int.MaxValue;
            foreach (int item in firstArray) 
            {
                if (item < min){
                    min = item;
                }
            }
            return min;
        }



        static int FindMax (int[] secondArray) 
        {
            int max = int.MinValue;
            foreach (int item in secondArray) 
            {
                if (item > max){
                    max = item;
                }
            }

            return max;
        }



        static void FillWaterArr (int[] secondArray, int arrayLength, int[] waterArray, int waterLvl)
        {
            for (int i = 0; i < arrayLength; i++)
            {
                if (secondArray [i] >= waterLvl) 
                {
                    waterArray [i] = 0;
                }else {
                    waterArray [i] = waterLvl - secondArray [i];
                }
            }
        }



        static void FillForOutputArr (int[] secondArr, int [,] forOutput, int waterLvl)
        {
            for (int j = 0; j < forOutput.GetLength(1); j=j+1)
            {   
                int air = 0;
                int land = 1;
                int water =2;
                
                int h = secondArr [j];
                

                for (int i = 0; i < forOutput.GetLength(0); i=i+1)
                {
                    int H = Abs (i - forOutput.GetLength(0) );
                    if (H <= h)
                    {
                        forOutput [i,j] = land;
                    } else {
                        if (H <= waterLvl){
                            forOutput [i,j] = water;
                        } else {
                            forOutput [i,j] = air;
                        }
                        
                    }
                }
            }
        }




        static void Print_Rect_and_Matrix (int width, int h, int [,] matrix) 
        {
            RectWidth (width);
            WriteLine ( " " );
            
            PrintMatrix (matrix);

            RectWidth (width);
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


        static void PrintMatrix (int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i ++) 
            {
                Write ("| ");
                for (int j = 0; j < matrix.GetLength(1); j ++)
                {
                    int value = matrix [i,j];
                    if (value == 1){
                        BackgroundColor = System.ConsoleColor.DarkGreen;
                        Write ("  ");
                    } else if (value == 2) {
                        BackgroundColor = System.ConsoleColor.DarkBlue;
                        Write ("  ");
                    } else {
                        BackgroundColor = System.ConsoleColor.White;
                        Write ("  ");
                    }
                    ResetColor();
                }
                Write (" |");
                WriteLine ();
            }
            ResetColor();
        }




        static void PrintHeights (int CursorStartPosition, int maxV, int width, int waterLvl)
        {
            for (int i = maxV + 1; i >= 0; i=i-1)
            {

                CursorTop = CursorStartPosition - i;
                
                CursorLeft = 2 * width;

                if (i == waterLvl){
                    Write ( " {0} (water level)", i );
                } else if (i == 0) {
                    WriteLine ( " {0}", i );
                } else {
                    Write ( " {0}", i );
                }

                    
            }
        }




        

        static int Mountain (int[] array, int max, int waterLvl)
        {
            int maxIndex=0;
            int area = 1;

            for (int i = 0; i <= array.Length-1; i++)
            {
                if (array[i] == max){
                    maxIndex = i;
                } else {
                    continue;
                }
            }

            for (int i = maxIndex; i <= array.Length-1; i++)
            {
                if ( ( (i+1) <= (array.Length-1) ) && ( array [i+1] > waterLvl ) ){
                    area++;
                } else {
                    break;
                }
            }



            for (int i = maxIndex; i >= 0; i=i-1)
            {
                if ( ( (i-1) >= 0 ) && ( array [i-1] > waterLvl ) ){
                    area++;
                } else {
                    break;
                }
            }   

            return area;
        }
        


    }
}

