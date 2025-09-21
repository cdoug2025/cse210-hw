using System.Runtime.InteropServices.Marshalling;

public class Reference
{
    private string _book;

    private int _chapter;

    private List<int> _verses = new();

    public Reference(string reference)
    {
        //split a reference into parts and assign values
        string[] referenceParts = reference.Split(' ', ',', ':').Where(verse => !string.IsNullOrWhiteSpace(verse)).ToArray();

        //If book is two or more parts like 1 Nephi or Words of Mormon, make the title one entry in the referenceParts array
        while (referenceParts[1].All(char.IsDigit) == false)
        {
            referenceParts[0] += " " + referenceParts[1];
            referenceParts = referenceParts.Where((_, index) => index != 1).ToArray();
        }

        //set _book and _chapter
        _book = referenceParts[0];
        _chapter = int.Parse(referenceParts[1]);

        //handling verses
        for (int arrayIndex = 2; arrayIndex < referenceParts.Length; arrayIndex++)
        {
            string verseReference = referenceParts[arrayIndex];

            //check if it is a single verse or multiple with a hyphen
            bool hasCharHyphen = false;
            foreach (char letter in verseReference)
            {
                if (letter == '-')
                {
                    hasCharHyphen = true;
                }
            }

            //if multiple verses
            if (hasCharHyphen == true)
            {
                string[] verseReferenceParts = verseReference.Split('-')
                    .Where(verse => !string.IsNullOrWhiteSpace(verse)).ToArray(); //error protection for multiple hyphens
                for (int verse = int.Parse(verseReferenceParts[0]); verse <= int.Parse(verseReferenceParts[1]); verse++)
                {
                    _verses.Add(verse);
                }
            }

            //if single verse
            else
            {
                _verses.Add(int.Parse(verseReference));
            }

        }
        //sort verse list to make sure it is in order
        _verses.Sort();
    }

    //should probably be rewritten to actually read a csv file
    public void LoadAndSaveToFile()
    {
        string[] linesArray = System.IO.File.ReadAllLines("Scriptures.csv");
        List<string> lines = linesArray.ToList();
        foreach (int verse in _verses)
        {
            string reference = $"{_book} {_chapter}:{verse}"; //set reference for file searching
            bool verseFound = false;
            int lineIndex = 0;

            //set line index to replace reference if already there, otherwise add it
            for (int loopLineIndex = 0; loopLineIndex < lines.Count; loopLineIndex++)
            {
                //set values for line parts and lineIndex
                lineIndex = loopLineIndex;
                string[] lineParts = lines[lineIndex].Split(',');
                string referenceFromFile = lineParts[0];

                if (reference == referenceFromFile)
                {
                    verseFound = true;
                    break;
                }
            }

            //verse not in file
            if (verseFound == false)
            {
                lines.Add("");
                lineIndex += 1;
            }

            //get scripture text
            Console.WriteLine($"Please provide text for {reference}");
            string scriptureText = Console.ReadLine();
            lines[lineIndex] = reference + ",\"" + scriptureText + "\"";
        }

        using (StreamWriter outputFile = new StreamWriter("Scriptures.csv"))
        {
            foreach (string line in lines)
            {
                outputFile.WriteLine(line);
            }
        }
    }

    //should probably be rewritten to actually read a csv file
    public string LoadFromFile()
    {
        string[] lines = System.IO.File.ReadAllLines("Scriptures.csv");
        string returnText = "";
        foreach (int verse in _verses)
        {
            string reference = $"{_book} {_chapter}:{verse}"; //set reference for file searching
            bool verseFound = false;
            foreach (string line in lines)
            {
                //set values for line parts
                string[] linePartsArray = line.Split(',');
                List<string> lineParts = linePartsArray.ToList();
                string referenceFromFile = lineParts[0];
                string scriptureText = lineParts[1];

                if (reference == referenceFromFile)
                {
                    //handle a verse with commas
                    while (lineParts.Count > 2)
                    {
                        scriptureText += "," + lineParts[2];
                        lineParts.RemoveAt(2);
                    }

                    //get rid of quotation marks around verse that ensure a csv reader avoids commas inside the verse
                    for (int scriptureTextCharIndex = 0; scriptureTextCharIndex < scriptureText.Length; scriptureTextCharIndex++)
                    {
                        if (scriptureTextCharIndex == 0 || scriptureTextCharIndex == scriptureText.Length - 1)
                        {
                            scriptureText = scriptureText.Remove(scriptureTextCharIndex, 1);
                        }
                    }

                    //save text for returning and set verseFound to true
                    returnText += scriptureText;
                    verseFound = true;
                    break;
                }
            }

            //handle scripture not in file
            if (verseFound == false)
            {
                //save scripture to file if user wants
                Console.WriteLine($"{reference} not found. Would you like to save new text for future access? (y/n)");
                if (Console.ReadLine() == "y")
                {
                    Reference newReferenceObject = new(reference);
                    newReferenceObject.LoadAndSaveToFile();
                    returnText = newReferenceObject.LoadFromFile();
                }

                //save for use if not saving to file
                else
                {
                    Console.WriteLine($"Please provide scripture text for {reference}");
                    string scriptureText = Console.ReadLine();
                    returnText += scriptureText;

                }
            }

        }

        //return
        return returnText;
    }

    // I could have saved the reference and just returned that, but I thought that not having an extra variable
    // that is only there to be read by other parts of the program would be a fun challenge.
    // Plus it gives error correction for typos in verses and reflects what is shown (if 2-1 is typed, it skips it)
    public string GetDisplayText()
    {
        //convert _verses (1, 2, 3, 5, 7, 8) to (1-3, 5, 7-8)
        bool firstVerse = true;
        _verses.Add(-1);
        string returnText = $"{_book} {_chapter}:";
        int lastVerse = -1;
        for (int verseIndex = 0; verseIndex < _verses.Count; verseIndex++)
        {
            int currentVerse = _verses[verseIndex];
            if (currentVerse != -1)
            {
                int nextVerse = _verses[verseIndex + 1];

                //handles verses
                //print ", "
                if (currentVerse - 1 != lastVerse && firstVerse == false)
                {
                    returnText += ", ";
                }

                //print end verse in a string of verses (5 in 5, and 10 in 8-10)
                if (currentVerse + 1 != nextVerse)
                {
                    returnText += currentVerse;
                }

                //print "-"
                if (currentVerse + 1 == nextVerse && currentVerse - 1 != lastVerse)
                {
                    returnText += currentVerse + "-";
                }

                //set last verse
                firstVerse = false;
                lastVerse = currentVerse;
            }
        }

        //return
        return returnText;
    }
}