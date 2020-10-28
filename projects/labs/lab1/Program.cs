using static System.Console;
using static System.Math;


class Program
{
    static void Main()
    {
        // -------------------part 1
        
        double a;
        double b;
        double c;

        WriteLine(">PART 1. Calculation");
        WriteLine(" ");
        WriteLine("Enter a:");
        a = double.Parse(ReadLine());
        WriteLine("Enter b:");
        b = double.Parse(ReadLine());
        WriteLine("Enter c:");
        c = double.Parse(ReadLine());
        double not_c = 0;

        if (a == b || a == (-b)) {
            WriteLine ("a is not valid");
        } else if (b == a || b == (-a)) {
            WriteLine ("b is not valid");
        }else if (c == not_c) {
            WriteLine ("c is not valid");
        } else {
            double d0;
            double d0_numerator;
            double d0_denominator;

            d0_numerator = Pow( (a+3), (c+1) ) - 10;
            double v = (a - b);
            d0_denominator = v;
            d0 = d0_numerator / d0_denominator;

            double d1;
            d1 = b / ( 11 * Abs(a+b) );

            double d2;
            double pow_part1;
            double pow_part2;

            pow_part1 = 6 + Sin(b);
            pow_part2 = ( Cos(a) ) / c;
            d2 = Pow(pow_part1, pow_part2);

            double d;
            d = d0 + d1 + d2;

            WriteLine ("a = {0}" , a);
            WriteLine ("b = {0}" , b);
            WriteLine ("c = {0}" , c);
            WriteLine ("d0 = {0}" , d0);
            WriteLine ("d1 = {0}" , d1);
            WriteLine ("d2 = {0}" , d2);
            WriteLine ("d = {0}" , d);
        }
        
        //----------------------part 2
        WriteLine(" ");
        WriteLine(">PART 2. Piecewise function");
        WriteLine(" ");
        double x;
        WriteLine("Enter x:");
        x = double.Parse(ReadLine());
        double y = 0;
        // not x: 2, 1/2;
        if ( (x>-10 && x<=-5) || (x>=5 && x<10) ){
            y = Cos(1.5 * x - 2) / (-x +2);
        WriteLine("x: {0}", x);
        WriteLine("y: {0}", y);

        } else {
            if (x == 0.5){
                y = double.NaN;
            }else{
                y = -2 / ((4*x - 1) - 1);
            } 
        WriteLine("x: {0}", x);
        WriteLine("y: {0}", y);  
        }
        
    }
}

