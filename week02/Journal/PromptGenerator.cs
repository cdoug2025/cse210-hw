public class PromptGenerator
{
    //prompt list
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Who did I help today?",
        "What is the best thing I ate today?",
        "What is something I learned today?",
        "What could be a headline for my day?",
        "What have I accomplished today?",
        "What is the funniest thing I saw today?",
        "What is the cutest animal I saw today?"
    };

    //generator
    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int randomIndex = randomGenerator.Next(0, _prompts.Count);
        return _prompts[randomIndex];
    }
}