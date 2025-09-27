using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        //create hide and seek comments
        List<Comment> hideAndSeekComments = [
            new Comment("JordanIsBest123", "Wow, this is so cool!"),
            new Comment("338remrofsnarT", "No way this is real"),
            new Comment("DarKVoIdSlaYEr1", "9:36 I can't stop laughing"),
        ];

        //create and display hide and seek video
        Video hideAndSeekVideo = new("We Played Hide and Seek in a Haunted House! (SCARY!)", "DocMatter", 1379, hideAndSeekComments);
        Console.WriteLine(hideAndSeekVideo.GetDisplayText());

        Console.WriteLine();

        //create art comments
        List<Comment> artComments = [
            new Comment("HuddledToast157", "I love this! It makes me want to draw this as well!"),
            new Comment("N3rd4", "At 3:37, you could have used a better strategy"),
            new Comment("HuddledToast157", "@N3rd4 Anyone can draw in a way that's best for them. There is no right way to draw!"),
            new Comment("Bot634527698432864e02", "I am a bot"),
        ];

        //create and display art video
        Video artVideo = new("How to Create a Custom Creature", "Treat-Or-Trick", 529, artComments);
        Console.WriteLine(artVideo.GetDisplayText());

        Console.WriteLine();

        //create gaming comments
        List<Comment> gamingComments = [
            new Comment("Timmy3", "ths so col I wat to ply ths so bad pls tll me hw to ply"),
            new Comment("338remrofsnarT", "At 14:57, the car in the background is me"),
            new Comment("Bot634527698432864e02", "I am a bot"),
        ];

        //create and display gaming video
        Video gamingVideo = new("I Played a RANDOMIZED Creature Catcher game!", "IntroNotNeeded", 2183, gamingComments);
        Console.WriteLine(gamingVideo.GetDisplayText());
    }
}