using System;
using static System.Console;
using System.Diagnostics;
using static System.IO.File;


namespace lab6
{
    
    enum State
    {
        Initial,
        Identifier,
        NotId,
        Exit,
    }
    class Program
    {        
        struct Options
        {
            public bool isInteractiveMode;
            public string inputFile;
            public string outputFile;
            // errors
            public bool hasParsingError;
            public string parsingError;
        }
        static void Main(string[] args)
        {
            RunTests();
            WriteLine ("Command Line Arguments ({0}):", args.Length);
            
            for (int i = 0; i < args.Length; i++)
            {
                WriteLine ($"[{i}] \"{args[i]}\" ");
            }

            Options options = ParseOptions (args);

            if (options.isInteractiveMode)
            {
                while (true)
                {
                    WriteLine ("Enter identifiers. Or 'exit' to stop.");
                    string input = ReadLine();
                    if (input == "exit")
                    {
                        break;
                    }
                    //
                    bool func1 = CheckIdentifier (input);
                    WriteLine (func1);
                    //
                    int func2 = CountIdentifiers (input);
                    WriteLine ($"Number of identifiers: {func2}");
                    //
                    string[] forOutput =  GetAllIdentifiers(input);
                    string outString = String.Join("\r\n", forOutput);
                    WriteLine (outString);
                }                
            }
            
            else if (options.inputFile == "")
            {
                WriteLine ("error 222: no input file in standart mode");
            }
            else if (options.hasParsingError)
            {
                WriteLine (options.parsingError);
            }  
            else // input file +, no errors +
            {
                string standartInput;
                standartInput = ReadAllText(options.inputFile);
                
                string[] outp = GetAllIdentifiers(standartInput);

                if (options.outputFile == "")
                {
                    // concole
                    for (int c = 0; c < outp.Length; c++)
                    {
                        WriteLine(outp[c]);
                    }
                }
                else
                {
                    // output in file
                    string fileOutput = String.Join("\r\n", outp);
                    WriteAllText (options.outputFile, fileOutput);
                }
            }
        }

        static bool CheckIdentifier (string input)
        {
            if (input.Length == 0)
            {
                return false;
            }
            State state = State.Initial;
            foreach (char c in input)
            {
                if (state == State.Initial)
                {
                    if (!char.IsLetter(c) && c != '_')
                    {
                        return false;
                    }
                    else
                    {
                        state = State.Identifier;  
                        continue;                          
                    }
                }
                else if (state == State.Identifier)
                {
                    if (!char.IsLetter(c) && c != '_' && !char.IsNumber(c))
                    {
                        return false;
                    }
                    else 
                    {
                        continue;
                    }
                }
            }
            return true;
        }

        static int CountIdentifiers (string input)
        {
            if (input.Length == 0)
            {
                return 0;
            }

            State state = State.Initial;
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (state == State.Initial)
                {
                    if (char.IsLetter(input[i]) || input[i] == '_')
                    {
                        state = State.Identifier; 
                        counter += 1;
                        continue;
                    }
                    else
                    {
                        if (char.IsWhiteSpace(input[i]) || char.IsPunctuation(input[i]))
                        {
                            continue;
                        }
                        else
                        {
                            state = State.NotId;
                            continue;
                        }
                        
                    }
                }
                else if (state == State.Identifier)
                {
                    if (char.IsLetter(input[i]) || input[i] == '_' || char.IsNumber(input[i]))
                    {
                        continue;
                    }
                    else
                    {
                        if (char.IsWhiteSpace(input[i]) || char.IsPunctuation(input[i]))
                        {             
                            state = State.Initial;                                
                            continue; 
                        }
                        else
                        {
                            counter = counter - 1;
                            state = State.Initial;
                        }                        
                    }                          
                }  
                else // not id 
                {
                    if (char.IsWhiteSpace(input[i]) || char.IsPunctuation(input[i]))
                    {
                        state = State.Initial;  
                        continue;
                    }
                    else 
                    {
                        continue;
                    }                    
                }
            }
            return counter;
        }
       
        static string[] GetAllIdentifiers (string input)
        {
            int arraySize = 420;
            string[] identifierArray = new string[arraySize];
        
            if (input.Length == 0)
            {
                identifierArray = new string[0];
                return identifierArray;
            }
            
            State state = State.Initial;
            int counter = 0;
            string word = "";
            int r = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (state == State.Initial)
                {
                    if (char.IsLetter(input[i]) || input[i] == '_')
                    {
                        state = State.Identifier; 
                                              
                        word += input[i];
                        counter += 1;
                        continue; 
                    }
                    else
                    {
                        if (char.IsWhiteSpace(input[i]) || char.IsPunctuation(input[i]))
                        {
                            continue;
                        }
                        else
                        {
                            state = State.NotId;
                            continue;
                        }
                        
                    }
                }
                else if (state == State.Identifier)
                {
                    if (char.IsLetter(input[i]) || input[i] == '_' || char.IsNumber(input[i]))
                    {
                        word += input[i];
                        continue;
                    }
                    else
                    {
                        if (char.IsWhiteSpace(input[i]) || char.IsPunctuation(input[i]))
                        {             
                            state = State.Initial;  
                            identifierArray[r] = word;
                            r++;
                            word = "";                                
                            continue; 
                        }
                        else
                        {
                            counter = counter - 1;
                            word = "";
                            state = State.Initial;
                            continue;
                        }                        
                    }
                }
                else // not id
                {
                    if (char.IsWhiteSpace(input[i]) || char.IsPunctuation(input[i]))
                    {
                        state = State.Initial;  
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }            

            string[] identifierArray1 = new string[counter];
            for (int x = 0; x < identifierArray1.Length; x++)
            {
                identifierArray1[x] = identifierArray[x];
            }

            return identifierArray1;
        }

        static void RunTests ()
        {
            // Func #1
            Debug.Assert(CheckIdentifier("42isCool_") == false, "starts with 42");
            Debug.Assert(CheckIdentifier("/name") == false, "starts with /");
            Debug.Assert(CheckIdentifier("") == false, "empty input");
            Debug.Assert(CheckIdentifier("oh iWant more Ids") == false, "not one identifier");
            Debug.Assert(CheckIdentifier("not-not") == false, "incorrect char '-'");
            Debug.Assert(CheckIdentifier("xexe, moo") == false, "separator");
            Debug.Assert(CheckIdentifier("_hamster_") == true, "correct hamster with _");
            Debug.Assert(CheckIdentifier("hamster_13") == true, "just correct hamster");
            // Func #2
            Debug.Assert(CountIdentifiers("_name ") == 1, "id with whitespace");
            Debug.Assert(CountIdentifiers("name` nameee") == 1, "not correct separatorrrrrr");            
            Debug.Assert(CountIdentifiers("name`") == 0, "not correct separator");             
            Debug.Assert(CountIdentifiers("xexe,   ") == 1, "id with separator");            
            Debug.Assert(CountIdentifiers("") == 0, "empty input");
            Debug.Assert(CountIdentifiers(" ") == 0, "just space");
            Debug.Assert(CountIdentifiers(" ,,,  ") == 0, "just separators");
            Debug.Assert(CountIdentifiers("_tool; seconD2 First") == 3, "some ids with space");
            Debug.Assert(CountIdentifiers("neXt3, teext_`     moo ") == 2, "some ids without space");
            Debug.Assert(CountIdentifiers("neXt3, 2teext_    moo ") == 2, "number before id");
            // func #3
            Debug.Assert(String.Join(",", GetAllIdentifiers("neXt3, neext_`     moo ")) == "neXt3,moo", "2 words");
            Debug.Assert(String.Join(",", GetAllIdentifiers("")) == "", "empty input");
            Debug.Assert(String.Join(",", GetAllIdentifiers("i 4am duck_ meow` ")) == "i,duck_", "Ducky duck");
            Debug.Assert(String.Join(",", GetAllIdentifiers("mooo,_ident1f ")) == "mooo,_ident1f", "Moooo");
            Debug.Assert(String.Join(",", GetAllIdentifiers("_oomoon ")) == "_oomoon", "wtf is going on???");

            //WriteLine("damn, no bugs. *sad tester* ");
        }

        static Options ParseOptions (string[] args)
        {
            int inputFilesCounter = 0;
            //
            bool isInteractiveMode = false;
            string inputFile = "";
            string outputFile = "";
            bool hasParsingError = false;
            string parsingError = "";
            //
            bool [] isParsedArr = new bool[args.Length];
            int f = 0;
            while (f != args.Length)
            {
                for (int i = 0; i < isParsedArr.Length; i++)
                {
                    if (!isParsedArr[i])
                    {
                        string arg = args[i];
                        if (arg == "-i")
                        {
                            isInteractiveMode = true;
                            isParsedArr[i] = true;
                            f++;
                        }
                        else if (arg == "-o")
                        {
                            if (i+1 < args.Length)
                            {
                                if (isParsedArr[i+1] == false)
                                {
                                    if (args[i+1] != "")
                                    {
                                        outputFile = args[i+1];
                                        isParsedArr[i] = true;
                                        isParsedArr[i+1] = true;
                                        f+=2;
                                    }
                                    else
                                    {
                                        parsingError = "error: -_-";
                                        isParsedArr[i] = true;
                                        f++;
                                    }
                                }
                            }
                            else
                            {
                                parsingError = "error -_- : no output file";
                                isParsedArr[i] = true;
                                f++;
                            }                            
                        }
                        else if (arg[0] != '-' && arg != "")
                        {
                            inputFile = arg;
                            isParsedArr[i] = true;
                            f++;
                            inputFilesCounter++;
                        }
                        else // arg is unknown
                        {
                            parsingError = "error 42: unrecognized command line option '" + args[i] + "' ";
                            isParsedArr[i] = true;
                            f++;
                            break;
                        }                   
                    }
                }
                if (inputFilesCounter != 1)
                {
                    parsingError = "error 1101: too much input files.";
                }

                if (parsingError != "")
                {
                    hasParsingError = true;
                }
            }
            
            
            

            Options options = new Options();
            options.isInteractiveMode = isInteractiveMode;
            options.inputFile = inputFile;
            options.outputFile = outputFile;
            options.hasParsingError = hasParsingError;
            options.parsingError = parsingError;           

            return options;
        }

    }
}

