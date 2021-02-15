using System;
using static System.Console;
using System.Diagnostics;
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
        private Planet[] _items;
        private int _size;
        public ListPlanet()
        {
            _items = new Planet[16];
            _size = 0;
        }

        public void Add(Planet newPlanet)
        {
            EnsureCapacity(this.Count+1);
            _items[_size] = newPlanet;
            _size++;
        }
        
        public void Insert(int index, Planet newPlanet)
        {
            EnsureCapacity(this.Count+1);
            for(int i = this.Count; i > index; i-=1)
            {
                _items[i] = _items[i-1];
            }
            _items[index] = newPlanet;
            _size++;
        }
        public bool Remove(Planet planet) 
        {
            int toCheck = 0;
            for(int i = 0; i < this.Count; i++)
            {
                if(_items[i] == planet)
                {
                    this.RemoveAt(i);
                    toCheck++;
                    break;
                }
            }
            if(toCheck == 0)
            {
                return false;
            }
            return true;
        }
        public void RemoveAt(int index)
        {
            if(index < 0 || index > this.Count)
            {
                throw new Exception("> incorrect index.");
            }
            for(int i = index; i < this.Count; i++)
            {
                _items[i] = _items[i+1];
            }
            _size -= 1;
        }
        public void Clear()
        {
            this._size = 0;
        }
        
        public int Count 
        {
            get 
            {
                return _size;
            }
        }
        public int Capacity 
        {
            get 
            {
                return _items.Length;
            }
        }
        public Planet this[int index]
        {
            get 
            {
                if(index < 0 || index > this.Count)
                {
                    throw new Exception("> incorrect index.");
                }
                return _items[index];
            }
            set 
            {
                if(index < 0 || index > this.Count)
                {
                    throw new Exception("> incorrect index.");
                }
                _items[index] = value;
            }
        }
        private void EnsureCapacity(int newSize) 
        {
            if(newSize > this.Capacity)
            {
                Array.Resize(ref _items, this.Capacity * 2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch ssww = new Stopwatch();
            ssww.Start();
            // ------------- Part 1 -------------
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
            
            GenerateCSV(filePath, numberOfLinesCSV);
            // ------------- Part 2 -------------
            string path1 = "./firstInput.csv";
            string path2 = "./secondInput.csv";
            GenerateCSV(path1, 20);
            GenerateCSV(path2, 200000);

            ListPlanet list1 = new ListPlanet(); 
            list1 = ReadAllPlanets(path1);
            // PrintList(list1);
            ListPlanet list2 = new ListPlanet(); 
            list2 = ReadAllPlanets(path2);
            // PrintList(list2);
            ListPlanet coolList = new ListPlanet();
            coolList = FillMainList(list1, list2);
            //
            double listAverage = FindAverage(coolList);
            WriteLine($"average --> {listAverage}");
            coolList = DeleteSomething(coolList, listAverage); // not working :((((
            //
            string path3 = "./outputPart222222.csv";
            WriteAllPlanets(path3, coolList);
            ssww.Stop(); 
            WriteLine($"Elapsed = {ssww.Elapsed}");
        }

        static ListPlanet DeleteSomething(ListPlanet planets, double av)
        {
            for(int r = 0; r < planets.Count; r++)
            {
                if(planets[r].size < av)
                {
                    planets.Remove(planets[r]);
                }
            }
            return planets;
        }

        static double FindAverage(ListPlanet planets)
        {
            double av = 0;
            double sum = 0;
            for(int h = 0; h < planets.Count; h++)
            {
                sum += planets[h].size;
            }
            av = sum / (planets.Count - 1);
            return av;
        }

        static ListPlanet FillMainList(ListPlanet list1, ListPlanet list2)
        {
            ListPlanet mainList = new ListPlanet();
            int check = 0;
            for(int j = 0; j < list1.Count; j++)
            {
                check = 0;
                for(int y = 0; y < mainList.Count; y++)
                {
                    if(mainList[y].id == list1[j].id)
                    {
                        check++;
                        break;
                    }
                }    
                if(check != 0)
                {
                    continue;
                }
                mainList.Add(list1[j]);
            }
            
            for(int k = 0; k < list2.Count; k++)
            {
                check = 0;
                for(int y = 0; y < mainList.Count; y++)
                {
                    if(mainList[y].id == list2[k].id)
                    {
                        check++;
                        break;
                    }
                }    
                if(check != 0)
                {
                    continue;
                }
                mainList.Add(list2[k]);
            }
            return mainList;
        }

        static void GenerateCSV (string filePath, int numberOfLinesCSV)
        {
            Random random = new Random();
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
            sw.WriteLine(nameof(Planet.id) + "," + nameof(Planet.name) + "," + nameof(Planet.size) + "," + nameof(Planet.color));
            while(true)
            {
                if(numberOfLinesCSV == 0)
                {
                    break;
                }
                
                int newId = random.Next(1, numberOfLinesCSV);

                string newName = adjective[random.Next(0, adjective.Length)] + noun[random.Next(0, noun.Length)];
                double newSize = Math.Round(random.Next(100, 500) + random.NextDouble(), 3);
                int forColor = random.Next(0, colors.Length);
                string newColor = colors[forColor];

                Planet randomP = new Planet(newId, newName, newSize, newColor);
                string rPlanet = randomP.ToString();
                sw.WriteLine(rPlanet);
                numberOfLinesCSV-=1;
            }
            
            sw.Close();
        }

        static void PrintList(ListPlanet list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                WriteLine(list[i].ToString());
            }
        }

        static ListPlanet ReadAllPlanets(string path)
        {
            ListPlanet list1 = new ListPlanet(); 
            StreamReader sr = new StreamReader(path); 
            string s = "";
            while (true)
            {
                s = sr.ReadLine();
                if (s == null)
                {
                    break;
                }
                string[] colsInRow = s.Split(',');
                if(colsInRow.Length != 4)
                {
                    Exception ex = new Exception("incorrect format in csv row");
                    throw ex;
                }
                int forPlanetsId = 0;
                if(!int.TryParse(colsInRow[0], out forPlanetsId))
                {
                    continue;
                }
                Planet p1 = new Planet();
                p1.id = forPlanetsId;
                p1.name = colsInRow[1];
                p1.size = double.Parse(colsInRow[2]);
                p1.color = colsInRow[3];
                list1.Add(p1);
            }
            sr.Close();
            return list1;
        }

        static void WriteAllPlanets(string path, ListPlanet planets)
        {
            StreamWriter sw = new StreamWriter(path);
            string s = ""; 
            int i = 0;
            while (true)
            {
                if (i == planets.Count)
                {
                    break;
                }
                s = planets[i].ToString();
                sw.WriteLine(s);
                i++;
            }
            sw.Close();
        }
    }
}