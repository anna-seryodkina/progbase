using static System.Console;


class Program
{
    static void Main()
    {
        WriteLine("Enter a number:");
        int number = int.Parse(ReadLine());
        int digit1 = number %10; 
        int digit2 = (number / 10) %10;
        int digit3 = (number / 100) %10;
        int sum = digit1 + digit2 + digit3;
        WriteLine("Sum is {0}.", sum);
    }
}
