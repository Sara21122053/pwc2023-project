using System;

class Program
{
    static void Main(string[] args)
    {
       Assignment work1 = new Assignment("Harika Zhang", "Multiplication");
       Console.WriteLine(work1.GetSummary());

       MathAssignment work2 = new MathAssignment("Alena Hamdi", "Fractions", "5.6", "2 - 10");
       Console.WriteLine(work2.GetSummary());
       Console.WriteLine(work2.GetHomeworkList());

       WritingAssignment work3 = new WritingAssignment("Olivia Hamdi", "European History", "Beginnings of the Cid and Almoravid expansion");
       Console.WriteLine(work3.GetSummary());
       Console.WriteLine(work3.GetWritingInformation());
    }
}
