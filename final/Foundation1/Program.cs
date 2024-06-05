using System;

class Program{
    static void InitializeProgram(List<Video> videoList)
    {
        Comment comment1;Comment comment2;Comment comment3;
        Video video;List<Comment> commentList;

        comment1 = new Comment("Pheobe Thompson", "I really like this video, it was very detailed.");
        comment2 = new Comment("Rachel Zion", "Thanks this was very helpful, now i can do it by myself. !");
        comment3 = new Comment("Joey Downing", "Thank you so much!");
        commentList = new List<Comment>{comment1,comment2,comment3};
        video = new Video("Bolaji's Tutorials",
        "How to change your PC keyboard.", 600, commentList);
        videoList.Add(video);

        comment1 = new Comment("MrBing", "Lovely cover, definately adding this to my playlist!");
        comment2 = new Comment("Mathew Perry", "One of the best things I've heard...");
        comment3 = new Comment("Lowen John", "You have a nice voice...");
        commentList = new List<Comment>{comment1,comment2,comment3};
        video = new Video("Ed Sheeran Sings",
        "2002 - Cover.", 240, commentList);
        videoList.Add(video);

        comment1 = new Comment("Tom Wellings", "Thanks man, I was really struggling with getting my page to load fast!");
        comment2 = new Comment("SuperCoder", "Could you do something similar but with Python?");
        comment3 = new Comment("Monochrome", "I appreciate the video, but I think the program idea presented would be better if it was done in C#.");
        commentList = new List<Comment>{comment1,comment2,comment3};
        video = new Video("Solomon Codes",
        "JavaScript Tutorials - Using IntersectionObserver to minimize CSS Load Times", 480, commentList);
        videoList.Add(video);
    }
    static void Main(string[] args)
    {
        List<Video> videoList = new List<Video>{};
        InitializeProgram(videoList);
        foreach(Video video in videoList)
        {
            video.Display();
            Console.WriteLine();
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}