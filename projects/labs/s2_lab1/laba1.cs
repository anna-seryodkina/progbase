using System;
using static System.Console;
using System.IO;

namespace s2_lab1
{
    class Planet
    {
        public int id;
        public string name;
        public double size;
        public string color;

        public Planet()
        {
            id = 0;
            name = "Earth";
            size = 100.001;
            color = "black";
        }
        public Planet(int planetId, string planetName, double planetSize, string planetColor)
        {
            this.id = planetId;
            this.name = planetName;
            this.size = planetSize;
            this.color = planetColor;
        }
        public override string ToString()
        {
            return $"{this.id},{this.name},{this.size},{this.color}";
        }
    }
    class ListPlanet
    {
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 2)
            {
                WriteLine("> error.");
                return;
            }
            int numberOfLinesCSV = 0; 
            if(int.TryParse(args[1], out numberOfLinesCSV) == false)
            {
                WriteLine("> error.");
                return;
            }
            if(numberOfLinesCSV < 0)
            {
                WriteLine("> error.");
                return;
            }

            string filePath = args[0]; // check if path is in correct format ?????
            
            Random random = new Random();
            int forId = 1;
            string[] adjective = new string[]
            {
                "happy", "boring", "super", "cool", "sad", "amazing", "lonely"
            };
            string[] noun = new string[]
            {
                "Apple", "Banana", "Mango", "Watemelon", "Pumpkin", "Tangerine", "Avocado"
            };
            string[] colors = new string[] 
            {
                "blue", "black", "white", "red", "green", "yellow", "pink", "purple", "orange"
            };

            StreamWriter sw = new StreamWriter(filePath);
            while(true)
            {
                if(numberOfLinesCSV == 0)
                {
                    break;
                }
                int newId = forId;
                forId++;
                string newName = adjective[random.Next(0, adjective.Length)] + noun[random.Next(0, noun.Length)];
                double newSize = random.Next(100, 500) + random.NextDouble();
                int forColor = random.Next(0, colors.Length);
                string newColor = colors[forColor];

                Planet randomP = new Planet(newId, newName, newSize, newColor);
                string rPlanet = randomP.ToString();
                sw.WriteLine(rPlanet);
                numberOfLinesCSV-=1;
            }
            
            sw.Close();
        }

        

        static ListPlanet ReadAllPlanets(string path)
        {
            throw new NotImplementedException();
        }

        static void WriteAllPlanets(string path, ListPlanet planets)
        {
            throw new NotImplementedException();
        }
    }
}

/* 
StreamReader sr = new StreamReader("./Program.cs");
string s = "";
while (true)
{
   s = sr.ReadLine();
   if (s == null)
   {
       break;
   }
   System.Console.WriteLine(s);
}
sr.Close();
---------------------------
StreamWriter sw = new StreamWriter("./Program22.cs");
StreamReader sr = new StreamReader("./Program.cs");
string s = "";
while (true)
{
   s = sr.ReadLine();
   if (s == null)
   {
       break;
   }
   sw.WriteLine(s);
}
sr.Close();
sw.Close();
---------------------------

*/
