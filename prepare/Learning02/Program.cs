using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Resume Lucia de la Cruz");

        Job job1 = new Job();
        job1._jobTitule = "Ballerina";
        job1._companyName = "English National Ballet School";
        job1._startYear = 2014;
        job1._endYear = 2018;
        //job1.Display();

        Job job2 = new Job();
        job2._jobTitule = "Ballerina / Assistant choreographer";
        job2._companyName = "Sadler's Wells Theatre";
        job2._startYear = 2018;
        job2._endYear = 2023;
        //job2.Display();

        Resume luciaResume = new Resume();
        luciaResume._name = "Lucia de la Cruz";
        luciaResume._jobs.Add(job1);
        luciaResume._jobs.Add(job2);
        luciaResume.Display();
    }
}
