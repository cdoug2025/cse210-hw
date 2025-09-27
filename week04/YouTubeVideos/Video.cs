public class Video
{
    private string _title;

    private string _author;

    private int _length; //in seconds

    private List<Comment> _comments;

    public Video(string title, string author, int length, List<Comment> comments)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = comments;
    }

    public int GetCommentNumber()
    {
        int number = 0;
        foreach (Comment comment in _comments)
        {
            number += 1;
        }
        return number;
    }

    public string GetDisplayText()
    {
        string returnText = $"Title: {_title}\nPosted by: {_author}\nLength in seconds: {_length}\n";
        foreach (Comment comment in _comments)
        {
            returnText += $"\n{comment.GetDisplayText()}\n";
        }
        return returnText;
    }
}