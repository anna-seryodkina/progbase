using System;
using static System.Console;
using static System.Math;
using Progbase.Procedural;

class lab4
{
    struct Point
    {
        public double x;
        public double y;
    }


    static void Main()
    {        
        const int size = 80;
        Point A = new Point {x = size/2, y = size/2};
        Point B = new Point {x = size/2, y = size/2};
        double r1 = 7;
        double r2 = 4;
        double r3 = 15;
        double alpha = PI/3;        

        Canvas.SetSize (size, size);
        Canvas.InvertYOrientation();

        Console.Clear();
        ConsoleKeyInfo key;

        do
        {
            B.x = r3 * Cos (alpha) + A.x;
            B.y = r3 * Sin (alpha) + A.y;

            Canvas.BeginDraw(); // --------------------------- begin

            Canvas.SetColor(255, 0, 0);
            Canvas.StrokeLine (0, 0, size, size);

            Canvas.SetColor(200, 200, 255);
            Canvas.FillCircle((int)A.x, (int)A.y, (int)r1);

            Canvas.SetColor(0, 255, 0);
            Canvas.PutPixel ((int)A.x, (int)A.y);

            Canvas.SetColor(255, 255, 255);
            Canvas.FillCircle((int)B.x, (int)B.y, (int)r2);

            Canvas.SetColor(0, 0, 255);
            Canvas.PutPixel ((int)B.x, (int)B.y);
            


            Canvas.EndDraw(); // ------------------------------ end
            WriteLine();

            WriteLine ("Press F to quit.");
            

            key = Console.ReadKey();
            if (key.Key == ConsoleKey.W)
            {
                r3 += 1;
            }
            else if (key.Key == ConsoleKey.S)
            {
                r3 -= 1;
            }
            else if (key.Key == ConsoleKey.G)
            {
                if (r1-1 > 0)
                {
                    r1 += 1;
                }
                else 
                {
                    WriteLine();
                    WriteLine("oops");
                    break;
                }
            }
            else if (key.Key == ConsoleKey.H)
            {
                if (r1-1 > 0)
                {
                    r1 -= 1;
                }
                else 
                {
                    WriteLine();
                    WriteLine("oops");
                    break;
                }
            }
            else if (key.Key == ConsoleKey.A)
            {
                if (A.x > 0 )
                {
                    A.x -=1;
                    A.y -=1;
                }
            }
            else if (key.Key == ConsoleKey.D)
            {
                if (A.x < size-1)
                {
                    A.x +=1;
                    A.y +=1;
                }
            }
            else if (key.Key == ConsoleKey.Q)
            {
                alpha += PI / 10;
            }
            else if (key.Key == ConsoleKey.E)
            {
                alpha -= PI / 10;
            }
            else if (key.Key == ConsoleKey.R)
            {
                if (r2-1 > 0)
                {
                    r2 += 1;
                }
                else 
                {
                    WriteLine();
                    WriteLine("oops");
                    break;
                }
            }
            else if (key.Key == ConsoleKey.T)
            {
                if (r2-1 > 0)
                {
                    r2 -= 1;
                }
                else 
                {
                    WriteLine();
                    WriteLine("oops");
                    break;
                }
            }
        } 
        while (key.Key != ConsoleKey.F); 
    }
}
