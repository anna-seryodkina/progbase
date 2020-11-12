using static System.Console;
using static System.Math;

namespace tasssk
{
    class Program
    {

        struct Books
        {
            public string title;
            public string author;
            public int year;
        }

        static void Main(string[] args)
        {

            static void PrintBook (Books book_1)
            {
                string t = book_1.title;
                string a = book_1.author;
                int y = book_1.year;
                WriteLine ("{0}, {1}, {2}", t, a, y);
            }




            Books book_1 = new Books
            {
                title = "The first book",
                author = "who knows",
                year = 4242
            };




            PrintBook (book_1);
            

            Books[] bookArray = new Books[3] {
                new Books {
                    title = "the second book",
                    author = "still don't know the author",
                    year = 3131
                },

                new Books {
                    title = "the third book",
                    author = "who wrote this???",
                    year = 8181
                },

                new Books {
                    title = "the 4th book",
                    author = "secret writer",
                    year = 2121,
                }
            };


            PrintBook( bookArray [0]);
            PrintBook( bookArray [1]);
            PrintBook( bookArray [2]);


            WriteLine ( "Enter num:" );
            

















            /*

            static double Gx(double x){
                double g = Cos(Pow (x,2)) / (Pow (Sin (2 * x ),2) +1);
                return g;
            }

            static double Hx(double x){
                double h = (Pow (x,2) + 3) / (2-x);
                return h;
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



           





            double xMin;
            double xMax;
            int nSteps;
            

            WriteLine("Enter min:");
            xMin = double.Parse(ReadLine());

            WriteLine("Enter max:");
            xMax = double.Parse(ReadLine());

            if (xMin >= xMax){
                WriteLine("is not correct"); 

            } else if (xMin <= 2 && 2 <= xMax) {
                WriteLine("can not be calculated");
            } else if () {

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



            /*
            double notX_double; (x*i)
            notX_double = 


            int not_x = Ceiling (notX_double);


            */





            



        }
    }
}
