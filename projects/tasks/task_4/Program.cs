using static System.Console;
using static System.Math;


class Program
{
    static void Main()
    {
        // 1
        
        WriteLine("1.Enter x:");
        double x1 = double.Parse(ReadLine());
        x1 = Pow (x1,2) - Sin (x1);
        WriteLine(x1); 

        // 2
        
        WriteLine("2.Enter x:");
        double x2 = double.Parse(ReadLine());
        x2 = Sqrt(Pow(Cos(x2), 2) + Abs(x2));
        x2 = Ceiling(x2);
        WriteLine(x2);
        
        // 3
        
        WriteLine("3.Enter x:");
        double x3 = double.Parse(ReadLine());
        x3 = (1 / (x3 + 3) ) - ( (Pow (x3,2) + 50) / 2 );
        WriteLine(x3);

    }
}
