public class ScriptureWord
{
    private string _word;

    private bool _isHidden;

    public ScriptureWord(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public void HideWord()
    {
        _isHidden = true;
    }

    public void ShowWord()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        string returnText = _word;

        //if word is hidden, return _ for every letter
        if (_isHidden == true)
        {
            returnText = "";
            foreach (char character in _word)
            {

                if (char.IsLetterOrDigit(character))
                {
                    returnText += "_";
                }
                else
                {
                    returnText += character;
                }
            }
        }

        //return
        return returnText;
    }
}