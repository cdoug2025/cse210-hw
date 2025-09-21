using System.Diagnostics;

public class Scripture
{
    private Reference _reference;

    private List<ScriptureWord> _scriptureWords = new();

    public Scripture(Reference reference, string scripture)
    {
        _reference = reference;
        string[] words = scripture.Split(" ");
        foreach (string word in words)
        {
            ScriptureWord scriptureWord = new(word);
            _scriptureWords.Add(scriptureWord);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new();
        for (int hiddenSoFar = 0; hiddenSoFar < numberToHide; hiddenSoFar++)
        {
            if (!IsCompletelyHidden())
            {
                List<ScriptureWord> nonHiddenScriptureWords = _scriptureWords.Where(word => word.IsHidden() == false).ToList();
                int randomIndex = random.Next(nonHiddenScriptureWords.Count);
                nonHiddenScriptureWords[randomIndex].HideWord();
            }
        }
    }

    public void ShowAllWords()
    {
        foreach (ScriptureWord word in _scriptureWords)
        {
            word.ShowWord();
        }
    }

    public string GetDisplayText()
    {
        string returnText = _reference.GetDisplayText();
        foreach (ScriptureWord word in _scriptureWords)
        {
            returnText += " ";
            returnText += word.GetDisplayText();
        }
        return returnText;
    }

    public bool IsCompletelyHidden()
    {
        bool hidden = true;
        foreach (ScriptureWord word in _scriptureWords)
        {
            if (!word.IsHidden())
            {
                hidden = false;
            }
        }
        return hidden;
    }
}