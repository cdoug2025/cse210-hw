public class Journal
{
    List<Entry> _entries = new List<Entry>();

    public void AddEntry()
    {
        Entry newEntry = new Entry();
        newEntry.CreateEntry();
        _entries.Add(newEntry);
    }

    public void DeleteEntry()
    {
        if (_entries.Count > 0)
        {
            for (int i = 0; i < _entries.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _entries[i].Display();
                Console.WriteLine();
            }
            Console.Write("Please type the number of the entry you would like to delete: ");
            int delIndex = int.Parse(Console.ReadLine());
            delIndex -= 1;
            if (delIndex >= 0 && delIndex < _entries.Count)
            {
                _entries.RemoveAt(delIndex);
                Console.WriteLine("\nEntry Deleted");
            }
            else
            {
                Console.WriteLine($"\nFailed to find entry at index {delIndex + 1}");
            }
        }

        else
        {
            Console.WriteLine("No entries found. Try creating an new entry or loading your previous entries");
        }
    }

    public void SaveToFile()
    {
        Console.Write("Please enter the name of the file that you would like to save your entries to (ex: journal.txt): ");
        string file = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                entry.Write(outputFile);
            }
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Please enter the name of the file that you would like to load your entries from (ex: journal.txt): ");
        string file = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(file);
        foreach (string line in lines)
        {
            Entry newEntry = new Entry();
            newEntry.Read(line);
            _entries.Add(newEntry);
        }
    }

    public void DisplayAll()
    {
        if (_entries.Count > 0)
        {
            for (int i = 0; i < _entries.Count; i++)
            {
                _entries[i].Display();
                if (i < _entries.Count - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}