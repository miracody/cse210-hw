using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video v1 = new Video("Intro to C#", "Mirabel", 300);
        v1.AddComment(new Comment("Carlos", "Great explanation!"));
        v1.AddComment(new Comment("Ana", "Very helpful."));
        v1.AddComment(new Comment("Luis", "Thanks for sharing!"));

        Video v2 = new Video("Crochet Basics", "Romira Global", 600);
        v2.AddComment(new Comment("Maria", "Love this tutorial."));
        v2.AddComment(new Comment("Pedro", "Clear and easy to follow."));
        v2.AddComment(new Comment("João", "Can you make part 2?"));

        // Store videos in a list
        List<Video> videos = new List<Video> { v1, v2 };

        // Display each video
        foreach (Video v in videos)
        {
            v.Display();
        }
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        foreach (Comment c in comments)
        {
            Console.WriteLine($" - {c.CommenterName}: {c.Text}");
        }
        Console.WriteLine();
    }
}    

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}