using static System.Console;
using static System.Math;

class Program
{
    static double Gx(double x){
        double g = Cos(1.5 * x - 2) / (-x +2);
        return g;
    }

    static double Hx(double x){
        double h = -2.0 / ( (4.0*x - 1.0) - 1.0);
        return h;
    }
    
    static double Fx(double x){
        if ( (x>=-4.5 && x<-1) || (x>1 && x<=4.5) ){
            if (x==2){
                double y = double.NaN;
                return y;
            }else {
                double y = Gx(x);
                return y;
            }
        } else {
            if (x == 0.5){
                double y = double.NaN;
                return y;
            }else{
                double y = Hx(x);
                return y;
            }  
        }
    } 
    static double Fx_task2(double x){
        if ( (x>=-4.5 && x<-1) || (x>1 && x<=4.5) ){

            double y = Gx(x);
            return y;
            
        } else {

            double y = Hx(x);
            return y;  
        }
    }

    static double IntFx(double xMin, double xMax, int nSteps){
        double step;
        step = (xMax - xMin) / nSteps;

        double sum = 0;

        for(double i = 0; i<= (nSteps - 1); i++){
            double part = Fx_task2(xMin + i * step);
            sum = sum + part;
        }
        
        double Int = step * sum;
        return Int;
    }

    static void Main()
    {
        
        WriteLine(">PART 1. Function");
        WriteLine(" ");

        // --------------- part 1
        
        decimal x;
        double y;
        

        for (x = -10; x<=10; x+=0.5M){                       
            y = Fx((double)x);  
            Write ("y({0})", x); 
            CursorLeft = 10;
            Write ("= ");
            WriteLine (y);
        }


  
        
        // --------------- part 2
        WriteLine(" ");
        WriteLine(">PART 2. Numerical integration");
        WriteLine(" ");

        
        double xMin;
        double xMax;
        int nSteps;
        

        WriteLine("Enter min:");
        xMin = double.Parse(ReadLine());

        WriteLine("Enter max:");
        xMax = double.Parse(ReadLine());

        if (xMin >= xMax){
            WriteLine("is not correct"); 

        } else if(xMin <= 0.5 && 0.5 <= xMax){
            WriteLine("can not be calculated");

        } else if (xMin <= 2 && 2 <= xMax) {
            WriteLine("can not be calculated");
        } else {

            WriteLine("Enter number of steps:");
            nSteps = int.Parse(ReadLine());

            if (nSteps<=0){
                WriteLine("is not correct"); 
            } else {

                double integral = IntFx(xMin, xMax, nSteps);
                WriteLine("Integral: {0}", integral);
            }
        }
        

    }
}