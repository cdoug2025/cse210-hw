public class Entry
{
    string _prompt;
    string _entry;
    string _date;

    public void CreateEntry()
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        DateTime currentTime = DateTime.Now;
        _date = currentTime.ToShortDateString();
        _prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(_prompt);
        _entry = Console.ReadLine();
    }

    public void Write(StreamWriter outputFile)
    {
        outputFile.WriteLine($"{_prompt}~|~{_entry}~|~{_date}");
    }

    public void Read(string line)
    {
        string[] parts = line.Split("~|~");

        _prompt = parts[0];
        _entry = parts[1];
        _date = parts[2];
    }

    public void Display()
    {
        Console.WriteLine(_prompt);
        Console.WriteLine(_entry);
        Console.WriteLine(_date);
    }
}