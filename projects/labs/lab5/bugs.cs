using System;
using static System.Console;
using static System.IO.File;

namespace lab5
{
    struct Planet
    {
        public int id;
        public string name;
        public double size;
        public string color;
    }



    class lab5
    {
        
        static void Main(string[] args)
        {
            string input;
            WriteLine("> Enter command");
            input = ReadLine();
            
            int switcher = CheckInput(input); // return 1 2 3 4 or 5
            int charSwitcher = 0;
            int stringSwitcher = 0;
            int csvSwitcher = 0;

            while (switcher != 4)
            {
                if (switcher == 1)
                {
                    CharFunc(input, charSwitcher);
                }
                else if (switcher == 2)
                {
                    StringFunc(input, stringSwitcher);
                }
                else if (switcher == 3)
                {
                    CsvFunc(input, csvSwitcher);
                }
                else 
                {
                    OutputUnknownErr(input);
                    break;
                }



                WriteLine("> Enter command.");
                input = ReadLine();
                switcher = CheckInput(input);
            }            
        }


        // ----------- Functions:


        static void OutputUnknownErr (string input)
        {
            string output = input + " Unknown command.";
            WriteLine($"> {output}");
        }




        static int CheckInput (string input) // !pure function!
        {
            if (input.Contains("quit"))
            {
                return 4;
            }
            else if (input.StartsWith("char/"))
            {
                return 1;
            }            
            else if (input.StartsWith("string/"))
            {
                return 2;
            }
            else if (input.StartsWith("csv/"))
            {
                return 3;
            }
            else 
            {
                return 5;
            }
        }


        static int CheckChar (string input) // !pure function!
        {
            if (input.EndsWith("all"))
            {
                return 1;
            }
            else if (input.EndsWith("lower"))
            {
                return 2;
            }
            else if (input.EndsWith("number"))
            {
                return 3;
            }
            else if (input.EndsWith("alnum"))
            {
                return 4;
            }
            else
            {
                return 5;
            }
        }

        
        static void CharFunc(string input, int charSw)
        {
            charSw = CheckChar(input);

            if (charSw == 1)
            {
                CharAllFunc ();
            }
            else if (charSw == 2)
            {
                CharLowerFunc ();
            }
            else if (charSw == 3)
            {
                CharNumberFunc ();
            }
            else if (charSw == 4)
            {
                CharAlnumFunc ();
            }
            else 
            {
                OutputUnknownErr(input);
                return;
            }
        }




        static void CharAllFunc ()
        {
            for (int code = 0; code <= 127 ; code++)
            {
                char n = Convert.ToChar(code);
                WriteLine("{0} '{1}'", code, n);                
            }
        }

        static void CharLowerFunc ()
        {
            for (int code = 97; code <=122 ; code++)
            {
                char n = Convert.ToChar(code);
                Write($"{n, 2}");                
            }
            WriteLine();
        }

        static void CharNumberFunc ()
        {
            for (int code = 48; code <= 57; code++)
            {
                char n = Convert.ToChar(code);
                Write($"{n, 2}");                
            }
            WriteLine();
        }

        static void CharAlnumFunc ()
        {
            for (int code = 0; code <= 127; code++)
            {
                char n = Convert.ToChar(code);
                if (char.IsLetterOrDigit(n))
                {
                    Write($"{n, 2}");
                }
            }
            WriteLine();
        }


        static string defaultString = "";

        static int CheckString (string input)
        {
            if (input.EndsWith("print"))
            {
                return 1;
            }
            else if (input.Contains("/set/"))
            {
                return 2;
            }
            else if (input.Contains("/substr/"))
            {
                return 3;
            }
            else if (input.EndsWith("/lower"))
            {
                return 4;
            }
            else if (input.Contains("/contains/"))
            {
                return 5;
            }
            else 
            {
                return 6;
            }
        }


        static void StringFunc (string input, int stringSw)
        {
            stringSw = CheckString(input);
            if (stringSw == 1)
            {
                PrintStringAndLength(defaultString);
            }
            else if (stringSw == 2)
            {
                defaultString = SetNewString(defaultString, input);
            }
            else if (stringSw == 3)
            {
                PrintSubstring (input);
            }
            else if (stringSw == 4)
            {
                PrintLowerString ();
            }
            else if (stringSw == 5)
            {
                bool t_f = IsCharInString (input, defaultString);
                if (t_f)
                {
                    WriteLine(true);
                }
                else
                {
                    WriteLine(false);
                }
            }
            else
            {
                OutputUnknownErr(input);
                return;
            }
        }



        static void PrintStringAndLength (string str)
        {
            WriteLine ($"> {str}");
            WriteLine ($"> Length of this string: {str.Length}");
        }


        static string SetNewString (string defStr, string input) // !pure function!
        {
            string[] inputParts = input.Split("/");
            string newStr = inputParts[2];
            defStr = newStr;
            return defStr;
        }



        static void PrintSubstring (string input) 
        {
            string[] inputParts = input.Split("/");
            if (inputParts.Length != 4)
            {
                WriteLine ("> oops. You forgot about some parts of the command.");
                return;
            }

            string maybeIndex = inputParts[2];
            if (!char.IsNumber(maybeIndex[0]))
            {
                WriteLine ("> oops. Index should be a number.");
                return;
            }

            string lengthOrNotLength = inputParts[3];
            if (!char.IsNumber(lengthOrNotLength[0]))
            {
                WriteLine ("> oops. Length should be a number.");
                return;
            }

            int startIndex = int.Parse(maybeIndex);
            int L = int.Parse(lengthOrNotLength);            

            if (startIndex + L >= defaultString.Length)
            {
                WriteLine("> oops. Enter another length.");
                return; 
            }
            string subStr = defaultString.Substring(startIndex, startIndex+L);
            WriteLine($"> line: {subStr}");

        }



        static void PrintLowerString ()
        {
            string newStr = defaultString.ToLower();
            WriteLine ($"> {newStr}");
        }



        static bool IsCharInString (string input, string defaultString) // !pure function!
        {
            string[] inputParts = input.Split("/");
            char C = Convert.ToChar (inputParts[2]);
            bool isChar = false;     
            int s = 0;      

            for (int i = 0; i < defaultString.Length; i++)
            {
                isChar = (defaultString[i] == C);

                if (isChar) 
                {            
                    s++;
                }
            }
            if (s > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }



        static string csvStr = "";
        static string [,] csvTable = new string[0,0];
        static Planet[] planets = new Planet[0];




        static int CheckCsv(string input)  // !pure function!
        {
            if (input.EndsWith("load"))
            {
                return 1;
            }
            else if (input.EndsWith("text"))
            {
                return 2;
            }
            else if (input.EndsWith("table"))
            {
                return 3;
            }
            else if (input.EndsWith("entities"))
            {
                return 4;
            }
            else if (input.Contains("/get/"))
            {
                return 5;
            }
            else if (input.Contains("/set/"))
            {
                return 6;
            }
            else if (input.EndsWith("save"))
            {
                return 7;
            }
            else 
            {
                return 8;
            }
        }



        static void CsvFunc (string input, int csvSwitcher)
        {
            csvSwitcher = CheckCsv(input);
            

            if (csvSwitcher == 1)
            {
                csvStr = ReadAllText ("./data.csv");
                csvTable = CsvToTable (csvStr, csvTable);
                planets = TableToEntities (csvTable, planets);
            }
            else if (csvSwitcher == 2)
            {
                WriteLine();
                WriteLine ($"> {csvStr}");
            }
            else if (csvSwitcher == 3)
            {
                PrintCsvTable();
            }
            else if (csvSwitcher == 4)
            {
                PrintCsvEntities();
            }
            else if (csvSwitcher == 5)
            {
                GetAndPrintStruct(input);                
            }
            else if (csvSwitcher == 6)
            {
                planets = RefreshCsv(input);
                csvTable = EntitiesToTable (planets, csvTable);
                csvStr = TableToCsv (csvTable, csvStr);
            }
            else if (csvSwitcher == 7)
            {
                //save csv
                WriteAllText ("./data.csv", csvStr);
            }
            else 
            {
                OutputUnknownErr(input);
                return;
            }
        }


        static string[,] CsvToTable (string csvStr, string[,] csvTable) // !pure function!
        {
            string[] substrings = csvStr.Split("\r\n");

            for (int i = 0; i < substrings.Length; i++)
            {
                string[] subSubS = substrings[i].Split(','); 
                
                csvTable = new string[substrings.Length, subSubS.Length];                         
            }


            for (int i = 0; i < csvTable.GetLength(0); i++)
            {
                for (int j = 0; j < csvTable.GetLength(1); j++)
                {
                    string[] subSubS = substrings[i].Split(','); 

                    csvTable[i,j] = subSubS[j];
                }
            }

            return csvTable;            
        }



        static Planet[] TableToEntities (string[,] csvTable, Planet[] planets)
        {
            planets = new Planet[csvTable.GetLength(0)];
            string[] row = new string[csvTable.GetLength(1)];
            int u = 0;
            for (int x = 0; x < csvTable.GetLength(0); x++)
            {
                for (int y = 0; y < csvTable.GetLength(1); y++)
                {
                    row[y] = csvTable[x,y];
                }
                Planet n = CsvRowToPlanet (row);
                if (u < planets.Length)
                {
                    planets[u] = n;
                    u++;
                }               

            }

            return planets;
        }



        static Planet CsvRowToPlanet (string[] row)
        {            
            string check = row[0];
            if (row.Length < 4)
            {
                return new Planet();
            }
            else if (char.IsLetter(check[0]))
            {
                return new Planet();
            }


            int id = int.Parse(row[0]);
            string name = row[1];
            double size = double.Parse(row[2]);
            string color = row[3];

            Planet f = new Planet();
            f.id = id;
            f.name = name;
            f.size = size;
            f.color = color;
            return f;                      
        }

        


        static void PrintCsvTable()
        {
            for (int i = 0; i < csvTable.GetLength(0); i++)
            {
                for (int j = 0; j < csvTable.GetLength(1); j++)
                {
                    Write ($"{csvTable[i,j], 12}");
                }
                WriteLine();
                WriteLine();
            }
        }



        static void PrintCsvEntities()
        {
            for (int a = 1; a < planets.Length; a++)
            {
                WriteLine ($"{planets[a].id}, {planets[a].name}, {planets[a].size}, {planets[a].color}");
            }
            WriteLine();
        }




        static void GetAndPrintStruct(string input)
        {
            string[] inputParts = input.Split("/");
            if (inputParts.Length != 3)
            {
                WriteLine ("> oops. You forgot about some parts of the command.");
                return;
            }
            
            string mustBeIndex = inputParts[2];
            if (!char.IsNumber(mustBeIndex[0]))
            {
                WriteLine ("> oops. Index should be a number.");
                return;
            }

            int i = int.Parse(mustBeIndex);
            if (i!=0)
            {
                WriteLine ($"{planets[i].id}, {planets[i].name}, {planets[i].size}, {planets[i].color}");
            }
        }




        static Planet[] RefreshCsv(string input) // set
        {            
            string[] inputParts = input.Split("/");
            if (inputParts.Length != 5)
            {
                WriteLine ("> oops. You forgot about some parts of the command.");
            }
            
            int i = int.Parse(inputParts[2]);
            string field = inputParts[3];
            string newValue = inputParts[4];

            char[] newValChars = newValue.ToCharArray();
            foreach (char c in newValChars)
            {
                if (c == ',')
                {
                    WriteLine ("> oops. incorrect character.");
                    break;
                }
                else if (c == '"')
                {
                    WriteLine ("> oops. incorrect character.");
                    break;
                }
                else
                {
                    continue;
                }
            }           

            if (i!=0)
            {
                if (field == "id"){
                    planets[i].id = int.Parse(newValue);
                }
                else if (field == "name")
                {
                    planets[i].name = newValue;
                }
                else if (field == "size")
                {
                    planets[i].size = double.Parse(newValue);
                }
                else if (field == "color")
                {
                    planets[i].color = newValue;
                }
                else 
                {
                    WriteLine ("> oops. Wrong field.");
                }
                return planets;       
                             
            }
            else 
            {
                WriteLine("oops i don't have entity with index 0");
                return planets;
            }

            
        }




        static string[,] EntitiesToTable (Planet[] planets, string[,] csvTable) 
        {    
            string[] row = new string[csvTable.GetLength(1)];

            for (int d = 0; d < planets.Length; d++)
            {
                if (d == 0)
                {
                    row[0] = "id";
                    row[1] = "name";
                    row[2] = "size";
                    row[3] = "color";
                }
                else
                {
                    Planet n = planets[d];
                    row = PlanetToCsvRow (n, csvTable);
                    for (int a = 0; a < row.Length; a++)
                    {
                        csvTable[d,a] = row[a];
                    }
                }
            }
            return csvTable;
        }


        static string[] PlanetToCsvRow (Planet n, string[,] csvTable)
        {
            string[] row = new string [csvTable.GetLength(1)];

            row[0] = Convert.ToString(n.id);
            row[1] = n.name;
            row[2] = Convert.ToString (n.size);
            row[3] = n.color;

            return row;
        }



        static string TableToCsv (string[,] csvTable, string csvStr)
        {
            
            string[] strJ = new string[csvTable.GetLength(1)];
            string[] strI = new string[csvTable.GetLength(0)];

            for (int i = 0; i < csvTable.GetLength(0); i++)
            {                
                for (int j = 0; j < csvTable.GetLength(1); j++)
                {
                    strJ[j] = csvTable[i,j];
                }
                strI[i] = string.Join(",", strJ);
            }
            csvStr = string.Join("\r\n", strI);
            return csvStr;
        }

    }
}
