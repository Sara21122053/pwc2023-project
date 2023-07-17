using System;

class Program
{
    static void Main(string[] args)
    {
        Conference conference = new Conference("Academic", "Good Living Forum", "Conference against discrimination in the labor and legal field", DateTime.Now, TimeSpan.FromHours(2), "456 Elm St", "Marco Harris", 100);
        Reception reception = new Reception("Social", "Nina's Baptism", "Reception to celebrate the baptism of a 15-year-old girl", DateTime.Now, TimeSpan.FromHours(3), "789 Oak St", "gilguero@gmail.com");
        OutdoorMeeting outdoorMeeting = new OutdoorMeeting("Social", "Jerom's Birthday", "A 7-year-old's birthday will be celebrated outdoors along with a painting war", DateTime.Now, TimeSpan.FromHours(4), "321 Maple St", "Sunny");


        Console.WriteLine("Conference Event - Standard Details:");
        Console.WriteLine(conference.GetStandardDetails());

        Console.WriteLine("\nConference Event - Full Details:");
        Console.WriteLine(conference.GetFullDetails());

        Console.WriteLine("\nConference Event - Short Description:");
        Console.WriteLine(conference.GetShortDescription());


        Console.WriteLine("\nReception Event - Standard Details:");
        Console.WriteLine(reception.GetStandardDetails());

        Console.WriteLine("\nReception Event - Full Details:");
        Console.WriteLine(reception.GetFullDetails());

        Console.WriteLine("\nReception Event - Short Description:");
        Console.WriteLine(reception.GetShortDescription());


        Console.WriteLine("\nOutdoor Meeting Event - Standard Details:");
        Console.WriteLine(outdoorMeeting.GetStandardDetails());

        Console.WriteLine("\nOutdoor Meeting Event - Full Details:");
        Console.WriteLine(outdoorMeeting.GetFullDetails());

        Console.WriteLine("\nOutdoor Meeting Event - Short Description:");
        Console.WriteLine(outdoorMeeting.GetShortDescription());
    }
}
