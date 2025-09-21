//Not creativity, but important to know: The program only quits when enter is pressed once all words are hidden,
//  this is so you can easily can easily continue the program if a number option is typed (like 1 to show all words)

//Added menu system for extra choices, accessed by typing a number instead of pressing enter or typing quit
//Added save system where scriptures can be saved to and read from Scriptures.csv
//Also, default options are saved in DefaultValues.csv

//By default, the program has 1 Nephi 3:7, John 14:15, Matthew 5:14-16, James 1:5-6 saved
//By deafault, 1 Nephi 3:7 is loaded by default, and 6 words are hidden at a time

using System;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Windows.Markup;

class Program
{
    static void Main(string[] args)
    {
        //set base values
        bool quit;
        string memorizerInput;
        quit = false;
        string scriptureText;
        Random random = new();


        //changing base values read from DefaultValues.csv file
        string[] lines = System.IO.File.ReadAllLines("DefaultValues.csv");
        string[] lineParts = lines[0].Split(',');
        string defaultReference = lineParts[0];
        int defaultNumberToHide = int.Parse(lineParts[1]);
        Reference reference = new(defaultReference);
        int numberToHide = defaultNumberToHide;
        
        //loop for changing scripture
        do
        {
            //load scripture text and create scripture object
            scriptureText = reference.LoadFromFile();
            Scripture scripture = new(reference, scriptureText);

            //start main hiding loop
            do
            {
                //memorizer intro
                Console.Clear();
                Console.WriteLine("Welcome to the Scripture Memorizer Program!");

                Console.WriteLine("\nType a number to perform the specified action:");
                Console.WriteLine("1. Show all words");
                Console.WriteLine("2. Change how many words are hidden at a time");
                Console.WriteLine("3. Change scripture");
                Console.WriteLine("4. Change default settings");
                Console.WriteLine("5. Save new/overwrite scripture (type new text)");

                Console.WriteLine("\nPress enter to hide random words (or end the program if all words are hidden)");
                Console.WriteLine("Type 'quit' to exit the program at any time");
                Console.WriteLine($"\n{scripture.GetDisplayText()}");
                memorizerInput = Console.ReadLine();

                //Show all words
                if (memorizerInput == "1")
                {
                    scripture.ShowAllWords();
                }

                //Change how many words are hidden at a time
                else if (memorizerInput == "2")
                {
                    Console.WriteLine($"Please type the number of words you would like to be hidden at once. Current: {numberToHide}");
                    numberToHide = int.Parse(Console.ReadLine());
                }

                //Change scripture
                else if (memorizerInput == "3")
                {
                    Console.WriteLine("Please enter the new scripture reference (ex. '1 Nephi 3:7'; can include multiple verses (ex. '5-8' and '14, 17'))");
                    Console.WriteLine("Or type 'random' for a random scripture");
                    Console.WriteLine($"Current reference: {reference.GetDisplayText()}");
                    string newReference = Console.ReadLine();

                    //if random is typed
                    if (newReference.ToLower() == "random")
                    {
                        string[] randomReferenceLines = System.IO.File.ReadAllLines("Scriptures.csv");
                        int randomReferenceIndex = random.Next(randomReferenceLines.Length);
                        string[] randomReferenceLineParts = randomReferenceLines[randomReferenceIndex].Split(',');
                        newReference = randomReferenceLineParts[0];
                    }

                    //set new reference
                    reference = new(newReference);
                    break;
                }

                //change default settings
                else if (memorizerInput == "4")
                {
                    string settingsInput;
                    do
                    {
                        //default settings intro
                        Console.Clear();
                        Console.WriteLine("Default Settings");
                        Console.WriteLine("Change the settings for when you start the program");

                        Console.WriteLine("\nWhich default setting would you like to change:");
                        Console.WriteLine("1. Scripture");
                        Console.WriteLine("2. How many words are hidden at a time");
                        Console.WriteLine("3. Back to memorizer");
                        settingsInput = Console.ReadLine();

                        //Change default scripture
                        if (settingsInput == "1")
                        {
                            Console.WriteLine("Please type the new default reference (ex. '1 Nephi 3:7'; can include multiple verses (ex. '5-8' and '14, 17'))");
                            Console.WriteLine($"Current: {defaultReference}");
                            defaultReference = Console.ReadLine();
                            string defaultLine = defaultReference + "," + defaultNumberToHide;

                            using (StreamWriter outputFile = new StreamWriter("DefaultValues.csv"))
                            {
                                outputFile.WriteLine(defaultLine);
                            }
                        }

                        //Change how many words are hidden at a time by default
                        else if (settingsInput == "2")
                        {
                            Console.WriteLine($"Please type the new default number of words to hide. Current: {defaultNumberToHide}");
                            defaultNumberToHide = int.Parse(Console.ReadLine());
                            string defaultLine = defaultReference + "," + defaultNumberToHide;

                            using (StreamWriter outputFile = new StreamWriter("DefaultValues.csv"))
                            {
                                outputFile.WriteLine(defaultLine);
                            }
                        }

                        //end default settings
                    } while (settingsInput != "3");
                }

                //change default settings
                else if (memorizerInput == "5")
                {
                    Console.WriteLine("Please type the reference you would like to save/overwrite (ex. '1 Nephi 3:7'; can include multiple verses (ex. '5-8' and '14, 17'))");
                    Reference saveReference = new(Console.ReadLine());
                    saveReference.LoadAndSaveToFile();
                }

                //quit is typed or all words are hidden
                else if (memorizerInput.ToLower() == "quit" || scripture.IsCompletelyHidden() == true)
                {
                    quit = true;
                }

                //enter is pressed
                else if (memorizerInput == "")
                {
                    scripture.HideRandomWords(numberToHide);
                }

                //end loops
            } while (quit == false);
        } while (quit == false);
    }
}