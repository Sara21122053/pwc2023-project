using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Don't cry, my love", "Tara Tournesol", 120);
        Video video2 = new Video("Make a wish", "Hayya River", 157);
        Video video3 = new Video("Little Bell", "William Blanc", 185);

        video1.AddComment(new Comment("@Laisa6", "I like the melody you created, it is really soothing."));
        video1.AddComment(new Comment("@DaliaGaia", "It's a nice lullaby. what was your inspiration?"));
        video1.AddComment(new Comment("@Sancho", "What musical instruments did you use to create this melody?"));

        video2.AddComment(new Comment("@Malag23", "You have a great voice"));
        video2.AddComment(new Comment("@Moica", "I think it would be amazing if you added musical accompaniment."));
        video2.AddComment(new Comment("@Moringa", "It was amazing. Will you upload another song soon?"));

        video3.AddComment(new Comment("@NadiaElizabeth", "The music box is very nice, did you make it yourself ?"));
        video3.AddComment(new Comment("@Karla", "I loved it! What is the composer's name?"));
        video3.AddComment(new Comment("@Marionet", "Could you upload the complete song?"));

        List<Video> videoList = new List<Video>();
        videoList.Add(video1);
        videoList.Add(video2);
        videoList.Add(video3);

        foreach (Video video in videoList)
        {
            Console.WriteLine("Title: " + video._title);
            Console.WriteLine("Author: " + video._author);
            Console.WriteLine("Duaration: " + video._duration + " seconds");
            Console.WriteLine("Number of Comments: " + video.NumberComments());

            Console.WriteLine("Comments: ");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine(" - " + comment._name + ": " + comment._text);
            }

            Console.WriteLine();
        }

        Console.ReadLine();
    }
}
