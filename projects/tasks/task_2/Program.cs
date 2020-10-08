using static System.Console;


class Program
{
    static void Main()
    {
        int a;
        WriteLine("Enter number a:");
        a = int.Parse(ReadLine());
        int b;
        WriteLine("Enter number b:");
        b = int.Parse(ReadLine());
        int c;
        WriteLine("Enter number c:");
        c = int.Parse(ReadLine());

        int sum = a + b + c;
        WriteLine("Sum:");
        WriteLine(sum);

        double average;
        average = sum / 3.0;
        WriteLine("average:");
        WriteLine(average);

    }
}
